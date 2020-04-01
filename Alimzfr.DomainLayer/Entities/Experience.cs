using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Alimzfr.DomainLayer.Entities
{
    [Table("Tbl_Experience")]
    public class Experience
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string PersianJobTitle { get; set; }
        public string EnglishJobTitle { get; set; }
        public string PersianCompanyName { get; set; }
        public string EnglishCompanyName { get; set; }
        public string PersianDescription { get; set; }
        public string EnglishDescription { get; set; }
        [Column(TypeName = "date")]
        public DateTime FromDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? ToDate { get; set; }
        public bool IsCurrentJob { get; set; }
        public int SequenceNumber { get; set; }
    }
}
