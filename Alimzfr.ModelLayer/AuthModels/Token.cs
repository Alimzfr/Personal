using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace Alimzfr.ModelLayer.AuthModels
{
    public class Token
    {
        [JsonPropertyName("refreshToken")]
        [Required]
        public string RefreshToken { get; set; }
    }
}
