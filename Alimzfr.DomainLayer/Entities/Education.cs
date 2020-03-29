using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Alimzfr.DomainLayer.Entities
{
    [Table("Tbl_Education")]
    public class Education
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string PersianCourseName { get; set; }
        public string EnglishCourseName { get; set; }
        public string PersianDescription{ get; set; }
        public string EnglishDescription { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int Duration { get; set; }
        public string PersianEducationalInstitute { get; set; }
        public string EnglishEducationalInstitute { get; set; }
    }
}
