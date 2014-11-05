using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Common.Extensions.Extensions
{
    public static class ListExtensions
    {
        /// <summary>
        /// Returns a list of strings alphabetically sorted
        /// </summary>
        /// <param name="lst">list of strings to sort</param>
        /// <returns>list of strings</returns>
        public static List<string> AlphaSort(this List<string> lst)
        {

            lst.Sort(delegate(string str1, string str2)
            {
                return str1.CompareTo(str2);
            });

            return lst;
        }

        /// <summary>
        /// Sorts a given list of type T based on a class property. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="lst"></param>
        /// <param name="property"></param>
        /// <param name="desc"></param>
        /// <returns></returns>
        public static List<T> SortList<T>(List<T> lst, string property, bool desc)
        {
            if (lst.Any())
            {
                PropertyInfo pi = lst.First().GetType().GetProperty(property);
                if (pi != null)
                {
                    if (desc)
                    {
                        return lst.OrderByDescending(o => pi.GetValue(o, null)).ToList();
                    }
                 
                    return lst.OrderBy(o => pi.GetValue(o, null)).ToList();
                }
            }

            return lst;
        }
    }
}
