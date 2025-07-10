using System;
using System.Collections.Generic;
using System.Text;

namespace BSDateConverter.Models
{
    public class DateLogEntry
    {
        public int BS_Year { get; set; }
        public int BS_Month { get; set; }
        public DateTime EnglishDate { get; set; }
    }
}
