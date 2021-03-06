﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Alimzfr.ModelLayer.Models
{
    public class ExperienceDto
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string PersianJobTitle { get; set; }
        public string EnglishJobTitle { get; set; }
        public string PersianCompanyName { get; set; }
        public string EnglishCompanyName { get; set; }
        public string PersianDescription { get; set; }
        public string EnglishDescription { get; set; }

        public DateTime GregorianFromDate { get; set; }
        public string PersianFromDate { get => new PersianDateTime(GregorianFromDate).ToString(); }

        public DateTime? GregorianToDate { get; set; }
        public string PersianToDate
        {
            get
            {
                return GregorianToDate.HasValue ? new PersianDateTime((DateTime)GregorianToDate).ToString() : null;
            }
        }

        public bool IsCurrentJob { get; set; }
        public int SequenceNumber { get; set; }
    }
}
