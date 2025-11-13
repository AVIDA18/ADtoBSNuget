using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using BSDateConverter.Models;

namespace BSDateConverter
{
    /// <summary>
    /// Provides methods for converting between Bikram Sambat and Gregorian calendar dates.
    /// </summary>
    public static class DateConverter
    {
        private static readonly List<DateLogEntry> _data;

        static DateConverter()
        {
            var assembly = Assembly.GetExecutingAssembly();

            using (Stream stream = assembly.GetManifestResourceStream("BSDateConverter.Data.DateLog.json"))
            using (StreamReader reader = new StreamReader(stream))
            {
                string json = reader.ReadToEnd();
                _data = JsonConvert.DeserializeObject<List<DateLogEntry>>(json);
            }
        }

        /// <summary>
        /// Converts a Bikram Sambat date to Gregorian DateTime.
        /// </summary>
        /// <param name="BSDate">BS date in "YYYY-MM-DD" format</param>
        /// <returns>Corresponding Gregorian DateTime</returns>
        public static string ConvertBSToAD(string BSDate)
        {
            var parts = BSDate.Split('-' , '/');
            int year = int.Parse(parts[0]);
            int month = int.Parse(parts[1]);
            int day = int.Parse(parts[2]);

            var baseDate = _data
                .Where(x => x.BS_Year == year && x.BS_Month == month)
                .Select(x => x.EnglishDate)
                .FirstOrDefault();

            if (baseDate == default)
                throw new ArgumentException("Invalid BS year or month");

            var adDate = baseDate.AddDays(day - 1);
            return adDate.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// Converts a Gregorian DateTime to Bikram Sambat date string.
        /// </summary>
        /// <param name="ADDate">Gregorian DateTime</param>
        /// <returns>BS date in "YYYY-MM-DD" format</returns>
        public static string ConvertADToBS(string ADDate)
        {
            DateTime adDate = DateTime.Parse(ADDate);
            var baseEntry = _data
                .Where(x => x.EnglishDate <= adDate)
                .OrderByDescending(x => x.EnglishDate)
                .FirstOrDefault();

            if (baseEntry == null)
                throw new ArgumentException("Date out of range");

            int day = (adDate - baseEntry.EnglishDate).Days + 1;

            return $"{baseEntry.BS_Year:D4}-{baseEntry.BS_Month:D2}-{day:D2}";
        }
    }
}
