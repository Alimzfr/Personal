using System;
using System.Collections.Generic;
using System.Text;

namespace Alimzfr.ModelLayer.Models
{
    public class MenuItemDto
    {
        public int Id { get; set; }
        public DateTime CreatDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string PersianTitle { get; set; }
        public string EnglishTitle { get; set; }
        public string RoutLink { get; set; }
        public string IconName { get; set; }
        public int SequenceNumber { get; set; }
    }
}
