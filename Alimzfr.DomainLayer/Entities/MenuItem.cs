using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Alimzfr.DomainLayer.Entities
{
    [Table("Tbl_MenuItem")]
    public class MenuItem
    {
        public int Id { get; set; }
        public DateTime CreatDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string PersianTitle { get; set; }
        public string EnglishTitle { get; set; }
        public string RoutLink { get; set; }
        public string IconName { get; set; }
        public int SequenceNumber { get; set; }
    }
}
