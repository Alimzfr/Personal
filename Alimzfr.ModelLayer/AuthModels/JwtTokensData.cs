using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Alimzfr.ModelLayer.AuthModels
{
    public class JwtTokensData
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string DisplayName { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public string RefreshTokenSerial { get; set; }
        public DateTime AccessTokenExpirationDate { get; set; }
        public DateTime RefreshTokenExpirationDate { get; set; }
        public IEnumerable<Claim> Claims { get; set; }
    }
}
