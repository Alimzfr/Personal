using System;
using System.Collections.Generic;
using System.Text;

namespace Alimzfr.ModelLayer.Models
{
    public class CollegeEducationDto
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiyDate { get; set; }
        public string PersianDegreeLevel { get; set; }
        public string EnglishDegreeLevel { get; set; }
        public string PersianAcademicField { get; set; }
        public string EnglishAcademicField { get; set; }
        public string PersianUniversity { get; set; }
        public string EnglishUniversity { get; set; }
        public string PersianDescription { get; set; }
        public string EnglishDescription { get; set; }
        public DateTime GregorianGraduationDate { get; set; }
        public string PersianGraduationDate { get => GregorianGraduationDate.ToString(); }
    }
}
