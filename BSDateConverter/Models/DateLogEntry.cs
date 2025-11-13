using System;
using System.Collections.Generic;
using System.Text;

namespace BSDateConverter.Models
{
    /// <summary>
    /// Represents a mapping entry between Bikram Sambat and Gregorian dates.
    /// </summary>
    public class DateLogEntry
    {
        /// <summary>
        /// Gets or sets the Bikram Sambat year.
        /// </summary>
        public int BS_Year { get; set; }
        
        /// <summary>
        /// Gets or sets the Bikram Sambat month.
        /// </summary>
        public int BS_Month { get; set; }
        
        /// <summary>
        /// Gets or sets the corresponding Gregorian date.
        /// </summary>
        public DateTime EnglishDate { get; set; }
    }
}
