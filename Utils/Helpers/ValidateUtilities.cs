using System;
using System.Collections.Generic;
using System.Linq;

namespace Utils.Helpers
{
    public static class ValidateUtilities
    {
        public static void ThrowIfNull<T>(this T instance, string paramName, string customErrorMessage = null)
        {
            if (string.IsNullOrEmpty(paramName))
            {
                throw new InvalidOperationException("You should not pass null or empty string a paramName");
            }

            if (instance != null)
            {
                return;
            }

            var exception = customErrorMessage.NullOrEmpty()
                ? new ArgumentNullException(paramName: paramName)
                : new ArgumentNullException(paramName: paramName, message: customErrorMessage);

            throw exception;
        }

        public static bool NullOrEmpty(this string @string)
        {
            return string.IsNullOrEmpty(@string?.Trim());
        }
        
    }
}