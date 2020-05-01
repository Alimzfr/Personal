
using Alimzfr.DataLayer.Data;
using Alimzfr.DomainLayer.AuthEntities;
using Alimzfr.ServiceLayer.Extentions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alimzfr.ServiceLayer.Authentication
{
    public interface IRolesService
    {
        Task<List<Role>> FindUserRolesAsync(int userId);
        Task<bool> IsUserInRoleAsync(int userId, string roleName);
        Task<List<User>> FindUsersInRoleAsync(string roleName);
    }

    public class RolesService : IRolesService
    {
        private readonly ApplicationDbContext _context;

        public RolesService(ApplicationDbContext context)
        {
            _context = context;
            _context.CheckArgumentIsNull(nameof(_context));
        }

        public Task<List<Role>> FindUserRolesAsync(int userId)
        {
            var userRolesQuery = _context.UserRoles.Where(x => x.UserId == userId).Select(x => x.Role);

            return userRolesQuery.OrderBy(x => x.Name).ToListAsync();
        }

        public async Task<bool> IsUserInRoleAsync(int userId, string roleName)
        {
            var userRolesQuery = _context.UserRoles.Include(x => x.Role).Where(x => x.Role.Name == roleName && x.UserId == userId).Select(x => x.Role);
            var userRole = await userRolesQuery.FirstOrDefaultAsync();
            return userRole != null;
        }

        public Task<List<User>> FindUsersInRoleAsync(string roleName)
        {
            var roleUserIdsQuery = _context.UserRoles.Include(x => x.Role).Where(x => x.Role.Name == roleName).Select(x => x.UserId);
            return _context.Users.Where(user => roleUserIdsQuery.Contains(user.Id)).ToListAsync();
        }
    }
}