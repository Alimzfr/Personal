using System;
using System.Collections.Generic;
using System.Text;

namespace Alimzfr.ModelLayer.Models
{
    public class EducationDto
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public string PersianCourseName { get; set; }
        public string EnglishCourseName { get; set; }
        public string PersianDescription { get; set; }
        public string EnglishDescription { get; set; }

        public DateTime GregorianFromDate { get; set; }
        public string PersianFromDate { get => new PersianDateTime(GregorianFromDate).ToString(); }

        public DateTime GregorianToDate { get; set; }
        public string PersianToDate { get => new PersianDateTime(GregorianToDate).ToString(); }

        public string PersianEducationalInstitute { get; set; }
        public string EnglishEducationalInstitute { get; set; }
        public int Duration { get; set; }
    }
}
