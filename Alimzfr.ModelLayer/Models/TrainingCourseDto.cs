using System;
using System.Collections.Generic;
using System.Text;

namespace Alimzfr.ModelLayer.Models
{
    public class TrainingCourseDto
    {
        public int? Id { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string PersianCourseName { get; set; }
        public string EnglishCourseName { get; set; }
        public string PersianDescription { get; set; }
        public string EnglishDescription { get; set; }

        public DateTime? GregorianFromDate { get; set; }
        public string PersianFromDate
        {
            get
            {
                return GregorianFromDate.HasValue ? new PersianDateTime((DateTime)GregorianFromDate).ToString() : null;
            }
        }

        public DateTime? GregorianToDate { get; set; }
        public string PersianToDate
        {
            get
            {
                return GregorianToDate.HasValue ? new PersianDateTime((DateTime)GregorianToDate).ToString() : null;
            }
        }

        public string PersianEducationalInstitute { get; set; }
        public string EnglishEducationalInstitute { get; set; }
        public int Duration { get; set; }

        public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
