using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Alimzfr.DomainLayer.AuthEntities
{
    [Table("Auth_User")]
    public class User
    {
        public User()
        {
            UserRoles = new HashSet<UserRole>();
            UserTokens = new HashSet<UserToken>();
        }
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string DisplayName { get; set; }
        public bool IsActive { get; set; }
        public string SerialNumber { get; set; }
        public DateTimeOffset? LastLoggedIn { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<UserToken> UserTokens { get; set; }
    }
}
