

using Alimzfr.DataLayer.Data;
using Alimzfr.DomainLayer.AuthEntities;
using Alimzfr.ServiceLayer.Extentions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Alimzfr.ServiceLayer.Authentication
{
    public interface IUsersService
    {
        Task<string> GetSerialNumberAsync(int userId);
        Task<User> FindUserAsync(string username, string password);
        ValueTask<User> FindUserAsync(int userId);
        Task UpdateUserLastActivityDateAsync(int userId);
        ValueTask<User> GetCurrentUserAsync();
        int GetCurrentUserId();
        Task<(bool Succeeded, string Error)> ChangePasswordAsync(User user, string currentPassword, string newPassword);
    }

    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext _context;
        private readonly ISecurityService _securityService;
        private readonly IHttpContextAccessor _contextAccessor;

        public UsersService(
            ApplicationDbContext context,
            ISecurityService securityService,
            IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _context.CheckArgumentIsNull(nameof(_context));

            _securityService = securityService;
            _securityService.CheckArgumentIsNull(nameof(_securityService));

            _contextAccessor = contextAccessor;
            _contextAccessor.CheckArgumentIsNull(nameof(_contextAccessor));
        }

        public ValueTask<User> FindUserAsync(int userId)
        {
            return _context.Users.FindAsync(userId);
        }

        public Task<User> FindUserAsync(string username, string password)
        {
            var passwordHash = _securityService.GetSha256Hash(password);
            return _context.Users.FirstOrDefaultAsync(x => x.Username == username && x.Password == passwordHash);
        }

        public async Task<string> GetSerialNumberAsync(int userId)
        {
            var user = await FindUserAsync(userId);
            return user.SerialNumber;
        }

        public async Task UpdateUserLastActivityDateAsync(int userId)
        {
            var user = await FindUserAsync(userId);
            if (user.LastLoggedIn != null)
            {
                var updateLastActivityDate = TimeSpan.FromMinutes(2);
                var currentUtc = DateTimeOffset.UtcNow;
                var timeElapsed = currentUtc.Subtract(user.LastLoggedIn.Value);
                if (timeElapsed < updateLastActivityDate)
                {
                    return;
                }
            }
            user.LastLoggedIn = DateTimeOffset.UtcNow;
            await _context.SaveChangesAsync();
        }

        public int GetCurrentUserId()
        {
            var claimsIdentity = _contextAccessor.HttpContext.User.Identity as ClaimsIdentity;
            var userDataClaim = claimsIdentity?.FindFirst(ClaimTypes.UserData);
            var userId = userDataClaim?.Value;
            return string.IsNullOrWhiteSpace(userId) ? 0 : int.Parse(userId);
        }

        public ValueTask<User> GetCurrentUserAsync()
        {
            var userId = GetCurrentUserId();
            return FindUserAsync(userId);
        }

        public async Task<(bool Succeeded, string Error)> ChangePasswordAsync(User user, string currentPassword, string newPassword)
        {
            var currentPasswordHash = _securityService.GetSha256Hash(currentPassword);
            if (user.Password != currentPasswordHash)
            {
                return (false, "Current password is wrong.");
            }

            user.Password = _securityService.GetSha256Hash(newPassword);
            // user.SerialNumber = Guid.NewGuid().ToString("N"); // To force other logins to expire.
            await _context.SaveChangesAsync();
            return (true, string.Empty);
        }
    }
}
