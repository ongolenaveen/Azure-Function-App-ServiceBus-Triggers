using System;
using System.Collections.Generic;
using System.Linq;

namespace ServiceBus.Function.App.Utilities
{
    public static class Extensions
    {
        /// <summary>
        /// Throw Argument Exception when the received string value is null
        /// </summary>
        /// <param name="value">Value of the string</param>
        /// <param name="parameterName">Parameter Name</param>
        /// <returns>Raises Exception if the received string value is null or whitespace</returns>
        public static void ThrowIfIsNullOrWhitespace(this string value, string parameterName)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException(parameterName);
        }


        /// <summary>
        /// Throw Argument Exception when the received string value is null
        /// </summary>
        /// <param name="value">Value of the string</param>
        /// <param name="parameterName">Parameter Name</param>
        /// <returns>Raises Exception if the received string value is Null or Empty</returns>
        public static void ThrowIfIsNullOrEmpty(this string value, string parameterName)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(parameterName);
        }

        /// <summary>
        ///  Throw Argument Exception when the received object value is null
        /// </summary>
        /// <typeparam name="T">Type of Object</typeparam>
        /// <param name="obj">Object Value</param>
        /// <param name="parameterName">Parameter Name</param>
        public static void ThrowIfNull<T>(this T obj, string parameterName)
                where T : class
        {
            if (obj == null) throw new ArgumentNullException(parameterName);
        }

        /// <summary>
        /// Determines whether [is not null or any].
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">The object.</param>
        /// <returns>
        ///   <c>true</c> if [is not null or any] [the specified object]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNotNullAndAny<T>(this IEnumerable<T> obj)
        {
            return (obj != null && obj.Any());
        }
    }
}
