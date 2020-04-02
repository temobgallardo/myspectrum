using System.Text.RegularExpressions;

namespace MySpectrum.Shared.Utils
{
    public static class Util
    {
        public static bool CheckPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return false;
            }

            string expression = 
                @"^" +              // Matches beginning of a line
                @"(?!.*(.)\1)" +    // For repeated following characters
                @"(?=.*[A-Za-z])" + // at least a letter
                @"(?=.*[0-9])" +    // at least a digit
                @"([A-Za-z0-9])" +  // Lower and Upper case chars and a digit
                @"{5,12}" +         // Min 5 Max 12 characters
                @"$";               // Matches the end of the line
            return Regex.IsMatch(password, expression);
        }
    }
}
