using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Alimzfr.DomainLayer.Entities
{
    [Table("Tbl_SkillCategory")]
    public class SkillCategory
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string PersianCategoryName { get; set; }
        public string EnglishCategoryName { get; set; }
        public string CategoryColor { get; set; }

        public ICollection<Skill> Skill { get; set; }
    }
}
