using System.Text.RegularExpressions;

namespace Common.Extensions.Extensions
{
    public static class ValidationExtensions
    {

        /// <summary>
        /// Validates an email address. Returns true if it is valid.
        /// </summary>
        /// <param name="email">Email you want to validate</param>
        /// <returns>Boolean</returns>
        public static bool ValidEmail(this string email)
        {
            var regex = new Regex(@"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
                                    + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				                            [0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
                                    + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				                            [0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
                                    + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$");

            return regex.IsMatch(email);
        }

    }
}
