using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Alimzfr.DomainLayer.AuthEntities
{
    [Table("Auth_UserToken")]
    public class UserToken
    {
        public int Id { get; set; }
        public string AccessTokenHash { get; set; }
        public DateTimeOffset AccessTokenExpiresDateTime { get; set; }
        public string RefreshTokenIdHash { get; set; }
        public string RefreshTokenIdHashSource { get; set; }
        public DateTimeOffset RefreshTokenExpiresDateTime { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
