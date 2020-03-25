using System;
using System.Collections.Generic;
using System.Text;

namespace Alimzfr.DomainLayer.Entities
{
    public class Skill
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string PersianSkillName { get; set; }
        public string EnglishSkillName { get; set; }
        public string PersianDescription { get; set; }
        public string EnglishDescription { get; set; }
        public int Level { get; set; }
    }
}
