using System;
using System.Linq;

namespace HomepageDev.API
{
    /// <summary>
    /// Utils class to demonstrate simple utility methods that can be exposed via the UtilsController API endpoints.
    /// </summary>
    public static class Utils
    {
        private static readonly Random Rand = new Random();

        /// <summary>
        /// Generate a random string containing letters A-Z (upper and lower case) and numbers 0-9.
        /// </summary>
        /// <param name="length">The length, in number of characters, of the random string to be returned.</param>
        /// <returns></returns>
        public static string GenerateRandomString(int length)
        {
            const string randStringChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            return new string(
                Enumerable.Repeat(randStringChars, length)
                .Select(s => s[Rand.Next(s.Length)])
                .ToArray()
            );
        }

        /// <summary>
        /// Generate a random integer with a value between the specified inclusive lower and upper bounds.
        /// </summary>
        /// <param name="minValue">Lower bound</param>
        /// <param name="maxValue">Upper bound</param>
        /// <returns></returns>
        public static int GenerateRandomInteger(int minValue, int maxValue)
        {
            if (minValue > maxValue)
            {
                throw new ArgumentOutOfRangeException($"minValue ({minValue}) cannot be greater than maxValue ({maxValue}).");
            }

            // use maxValue + 1 becaue Rand.Next() range of returned value includes minValue but not maxValue
            return Rand.Next(minValue, maxValue + 1);
        }
    }
}
