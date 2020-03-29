using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Alimzfr.DomainLayer.Entities
{
    [Table("Tbl_About")]
    public class About
    {
        public int Id { get; set; }
        public DateTime CreatDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string PersianDescription { get; set; }
        public string EnglishDescription { get; set; }
    }
}
