using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alimzfr.DataLayer.Data;
using Alimzfr.ModelLayer.Models;
using Alimzfr.ServiceLayer.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Alimzfr.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly JwtService _jwtService;
        private readonly ApplicationDbContext _context;
        public UserController(JwtService jwtService, ApplicationDbContext context)
        {
            _jwtService = jwtService;
            _context = context;
        }

        [HttpPost]
        public TokenDto Login([FromBody]LoginDto login)
        {
            var userId = HttpContext.User;
            //var test = _jwtService.GenerateSecurityToken(login.Email);
            return new TokenDto { Access_token = "Hello World"};
        }

        [HttpGet]
        public void Logout()
        {
            //var test = _jwtService.GenerateSecurityToken(login.Email);
        }

    }
}