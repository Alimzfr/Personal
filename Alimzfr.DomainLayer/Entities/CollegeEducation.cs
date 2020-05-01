using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Alimzfr.DomainLayer.Entities
{
    [Table("Tbl_CollegeEducation")]
    public class CollegeEducation
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string PersianDegreeLevel { get; set; }
        public string EnglishDegreeLevel { get; set; }
        public string PersianAcademicField { get; set; }
        public string EnglishAcademicField { get; set; }
        public string PersianUniversity { get; set; }
        public string EnglishUniversity { get; set; }
        public string PersianDescription { get; set; }
        public string EnglishDescription { get; set; }

        [Column(TypeName = "date")]
        public DateTime? GraduationDate { get; set; }
    }
}
