using System;
using System.Collections.Generic;
using System.Text;

namespace Alimzfr.DomainLayer.Entities
{
    public class Experience
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiyDate { get; set; }
        public string PersianJobTitle { get; set; }
        public string EnglishJobTitle { get; set; }
        public string PersianCompanyName { get; set; }
        public string EnglishCompanyName { get; set; }
        public string PersianDescription { get; set; }
        public string EnglishDescription { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public bool IsCurrentJob { get; set; }
    }
}
