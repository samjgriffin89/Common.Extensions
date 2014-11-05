using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Common.Extensions.Extensions
{
    public static class DateExenstions
    {

        /// <summary>
        /// Loops over the given date range.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="thru"></param>
        /// <returns></returns>
        public static IEnumerable<DateTime> EachDay(DateTime from, DateTime to)
        {
            for (var day = from.Date; day.Date <= to.Date; day = day.AddDays(1))
                yield return day;
        }

        /// <summary>
        /// Converts an iso date formatted string and converts it to a DateTime. 
        /// Retruns minValue if string cannot be parsed.
        /// </summary>
        /// <param name="isoDate">string with iso formatted date</param>
        /// <returns>DateTime</returns>
        public static DateTime IsoToDateTime(this string isoDate)
        {
            if (isoDate.IsNotNullOrEmpty())
            {
                if (isoDate.Length > 15 && isoDate[15] == ':')
                {
                    string text = isoDate.Substring(16);
                    if (text.Length > 0)
                    {
                        return new DateTime(StringExtensions.GetLong(text, 0L));
                    }
                }

                int[] isoDateParts = GetIsoDateParts(isoDate);
                if (isoDateParts == null)
                {
                    return DateTime.MinValue;
                }
                
                if (isoDateParts.Length >= 6)
                {
                    return new DateTime(isoDateParts[0], isoDateParts[1], isoDateParts[2], isoDateParts[3], isoDateParts[4], isoDateParts[5]);
                }
                if (isoDateParts.Length >= 3)
                {
                    return new DateTime(isoDateParts[0], isoDateParts[1], isoDateParts[2]);
                }
            }

            return DateTime.MinValue;

        }

        private static int[] GetIsoDateParts(string isoDate)
        {
            if ((isoDate.Length != 8 && isoDate.Length != 15) || Regex.IsMatch(isoDate, "[^0-9T]"))
            {
                return null;
            }

            int[] dtArray = new int[6];
            dtArray[0] = StringExtensions.GetInt(isoDate.Substring(0, 4), 0);
            dtArray[1] = StringExtensions.GetInt(isoDate.Substring(4, 2), 0);
            dtArray[2] = StringExtensions.GetInt(isoDate.Substring(6, 2), 0);

            if (isoDate.Length > 8 && isoDate[8] == 'T')
            {
                dtArray[3] = StringExtensions.GetInt(isoDate.Substring(9, 2), 0);
                dtArray[4] = StringExtensions.GetInt(isoDate.Substring(11, 2), 0);
                dtArray[5] = StringExtensions.GetInt(isoDate.Substring(13, 2), 0);
            }
            return dtArray;
        }

    }
}
