using System;
using System.Collections.Generic;
using System.Text;

namespace Alimzfr.ModelLayer.Models
{
    public class SkillDto
    {
        public int? Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string PersianSkillName { get; set; }
        public string EnglishSkillName { get; set; }
        public string PersianDescription { get; set; }
        public string EnglishDescription { get; set; }
        public int Level { get; set; }
        public int? SkillCategoryId { get; set; }
        public string PersianCategoryName { get; set; }
        public string EnglishCategoryName { get; set; }
        public string CategoryColor { get; set; }
    }
}
