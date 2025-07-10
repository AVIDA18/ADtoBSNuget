using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using BSDateConverter.Models;

namespace BSDateConverter
{
    public static class BSDateConverter
    {
        private static readonly List<DateLogEntry> _data;

        static BSDateConverter()
        {
            var assembly = Assembly.GetExecutingAssembly();

            using (Stream stream = assembly.GetManifestResourceStream("BSDateConverter.Data.DateLog.json"))
            using (StreamReader reader = new StreamReader(stream))
            {
                string json = reader.ReadToEnd();
                _data = JsonConvert.DeserializeObject<List<DateLogEntry>>(json);
            }
        }

        public static DateTime ConvertBSToAD(string bsDate)
        {
            var parts = bsDate.Split('-');
            int year = int.Parse(parts[0]);
            int month = int.Parse(parts[1]);
            int day = int.Parse(parts[2]);

            var baseDate = _data
                .Where(x => x.BS_Year == year && x.BS_Month == month)
                .Select(x => x.EnglishDate)
                .FirstOrDefault();

            if (baseDate == default)
                throw new ArgumentException("Invalid BS year or month");

            return baseDate.AddDays(day - 1);
        }

        public static string ConvertADToBS(DateTime adDate)
        {
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
