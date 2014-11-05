using System.Collections.Generic;
using System.Linq;

namespace Common.Extensions.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Checks if the string is null or empty
        /// </summary>
        /// <param name="str">string to check</param>
        /// <returns>boolean</returns>
        public static bool IsNotNullOrEmpty(this string str)
        {
            return !string.IsNullOrEmpty(str);
        }

        /// <summary>
        /// Takes in a string and a delimiter and returns a list from the string
        /// </summary>
        /// <param name="str">string to explode</param>
        /// <param name="delimiter">what the list is split by</param>
        /// <returns>List of strings</returns>
        public static List<string> Explode(this string str, char delimiter)
        {
            // Split the string by the given delimiter and return as a list
            return str.IsNotNullOrEmpty() ? str.Split(delimiter).ToList() : new List<string>();
        }

        /// <summary>
        /// Implodes a list into a string delimited by the given delimiter parameter
        /// </summary>
        /// <param name="lst">List to join</param>
        /// <param name="delimiter">delimiter for string</param>
        /// <returns>string</returns>
        public static string Implode(this List<string> lst, string delimiter)
        {
            return lst.Any() ? string.Join(delimiter, lst.ToArray()) : string.Empty;
        }

        /// <summary>
        /// Parses a string to return an int. Returns the default value if the string cannot be parsed.
        /// </summary>
        /// <param name="str">integer as a string</param>
        /// <param name="defaultVal">default int value</param>
        /// <returns>int</returns>
        public static int GetInt(this string str, int defaultVal)
        {
            int result;
            return int.TryParse(str, out result) ? result : defaultVal;
        }

        /// <summary>
        /// Parses a string to return a long. Returns the default value if the string cannot be parsed.
        /// </summary>
        /// <param name="str">long as a string</param>
        /// <param name="defaultVal">default long value</param>
        /// <returns>long</returns>
        public static long GetLong(this string str, long defaultVal)
        {
            long result;
            return long.TryParse(str, out result) ? result : defaultVal;
        }
    }
}
