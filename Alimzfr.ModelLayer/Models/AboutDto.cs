using System;
using System.Collections.Generic;
using System.Text;

namespace Alimzfr.ModelLayer.Models
{
    public class AboutDto
    {
        public int Id { get; set; }
        public DateTime CreatDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public string PersianDescription { get; set; }
        public string EnglishDescription { get; set; }
    }
}
