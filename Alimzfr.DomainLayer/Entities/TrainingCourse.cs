using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Alimzfr.DomainLayer.Entities
{
    [Table("Tbl_TrainingCourse")]
    public class TrainingCourse
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string PersianCourseName { get; set; }
        public string EnglishCourseName { get; set; }
        public string PersianDescription{ get; set; }
        public string EnglishDescription { get; set; }
        [Column(TypeName = "date")]
        public DateTime FromDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? ToDate { get; set; }
        public int Duration { get; set; }
        public string PersianEducationalInstitute { get; set; }
        public string EnglishEducationalInstitute { get; set; }
    }
}
