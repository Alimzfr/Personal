using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Alimzfr.DomainLayer.Entities
{
    [Table("Tbl_UserMessage")]
    public class UserMessage
    {
        public int Id { get; set; }
        public DateTime CreatDate { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Comment { get; set; }
        public string UserAgentInfo { get; set; }
        public bool IsRead { get; set; }
    }
}
