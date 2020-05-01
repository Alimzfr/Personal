using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Alimzfr.DataLayer.Data;
using Alimzfr.DomainLayer.AuthEntities;
using Alimzfr.ModelLayer.AuthModels;
using Alimzfr.ServiceLayer.Authentication;
using Alimzfr.ServiceLayer.Extentions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Alimzfr.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class AuthController : ControllerBase
    {
        private readonly IUsersService _usersService;
        private readonly ITokenStoreService _tokenStoreService;
        private readonly ApplicationDbContext _context;
        private readonly IAntiForgeryCookieService _antiforgery;
        private readonly ITokenFactoryService _tokenFactoryService;

        public AuthController(
            IUsersService usersService,
            ITokenStoreService tokenStoreService,
            ITokenFactoryService tokenFactoryService,
            ApplicationDbContext context,
            IAntiForgeryCookieService antiforgery)
        {
            _usersService = usersService;
            _usersService.CheckArgumentIsNull(nameof(usersService));

            _tokenStoreService = tokenStoreService;
            _tokenStoreService.CheckArgumentIsNull(nameof(tokenStoreService));

            _context = context;
            _context.CheckArgumentIsNull(nameof(_context));

            _antiforgery = antiforgery;
            _antiforgery.CheckArgumentIsNull(nameof(antiforgery));

            _tokenFactoryService = tokenFactoryService;
            _tokenFactoryService.CheckArgumentIsNull(nameof(tokenFactoryService));
        }

        [AllowAnonymous]
        [IgnoreAntiforgeryToken]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody]User loginUser)
        {
            if (loginUser == null)
            {
                return BadRequest("user is not set.");
            }

            var user = await _usersService.FindUserAsync(loginUser.Username, loginUser.Password);
            if (user == null || !user.IsActive)
            {
                return Unauthorized();
            }

            var result = await _tokenFactoryService.CreateJwtTokensAsync(user);
            await _tokenStoreService.AddUserTokenAsync(user, result.RefreshTokenSerial, result.AccessToken, null);
            await _context.SaveChangesAsync();

            _antiforgery.RegenerateAntiForgeryCookies(result.Claims);

            return Ok(new
            {
                username = result.Username,
                displayName = result.DisplayName,
                email = result.Email,
                accessToken = result.AccessToken,
                refreshToken = result.RefreshToken
            });
        }

        [AllowAnonymous]
        [IgnoreAntiforgeryToken]
        [HttpPost]
        public async Task<IActionResult> RefreshToken([FromBody]Token model)
        {
            var refreshTokenValue = model.RefreshToken;
            if (string.IsNullOrWhiteSpace(refreshTokenValue))
            {
                return BadRequest("refreshToken is not set.");
            }

            var token = await _tokenStoreService.FindTokenAsync(refreshTokenValue);
            if (token == null)
            {
                return Unauthorized();
            }

            var result = await _tokenFactoryService.CreateJwtTokensAsync(token.User);
            await _tokenStoreService.AddUserTokenAsync(token.User, result.RefreshTokenSerial, result.AccessToken, _tokenFactoryService.GetRefreshTokenSerial(refreshTokenValue));
            await _context.SaveChangesAsync();

            _antiforgery.RegenerateAntiForgeryCookies(result.Claims);

            return Ok(new
            {
                username = result.Username,
                displayName = result.DisplayName,
                email = result.Email,
                accessToken = result.AccessToken,
                refreshToken = result.RefreshToken
            });
        }

        [AllowAnonymous]
        [IgnoreAntiforgeryToken]
        [HttpPost]
        public async Task<bool> Logout([FromBody]Token token)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userIdValue = claimsIdentity.FindFirst(ClaimTypes.UserData)?.Value;

            // The Jwt implementation does not support "revoke OAuth token" (logout) by design.
            // Delete the user's tokens from the database (revoke its bearer token)
            await _tokenStoreService.RevokeUserBearerTokensAsync(userIdValue, token.RefreshToken);
            await _context.SaveChangesAsync();

            _antiforgery.DeleteAntiForgeryCookies();

            return true;
        }

        [HttpGet, HttpPost]
        public bool IsAuthenticated()
        {
            return User.Identity.IsAuthenticated;
        }

        [HttpGet, HttpPost]
        public IActionResult GetUserInfo()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            return Ok(new { Username = claimsIdentity.Name });
        }

    }
}