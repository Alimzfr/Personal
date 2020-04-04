using System;
using System.Collections.Generic;
using System.Text;

namespace Alimzfr.ModelLayer.Models
{
    public class UserCommentDto
    {
        public int? Id { get; set; }
        public DateTime? CreatDate { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Comment { get; set; }
        public string UserAgentInfo { get; set; }
        public bool IsRead { get; set; }
    }
}
