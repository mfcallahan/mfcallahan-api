using System;
using System.Linq;
using System.Threading;

namespace HomepageDev.API.Utils
{
    /// <summary>
    /// Utility class to demonstrate simple methods that can be exposed via the UtilsController API endpoints.
    /// </summary>
    public static class Utilities
    {
        private static readonly Random Rand = new Random();

        /// <summary>
        /// Generate a random string containing letters A-Z (upper and lower case) and numbers 0-9.
        /// </summary>
        /// <param name="length">The length, in number of characters, of the random string to be returned.</param>
        /// <returns>A string of random characters.</returns>
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
        /// <returns>A random integer</returns>
        public static int GenerateRandomInteger(int minValue, int maxValue)
        {
            if (minValue > maxValue)
            {
                throw new ArgumentOutOfRangeException(nameof(minValue), $"Value of parameter {nameof(minValue)} ({minValue}) cannot be greater than value of parameter {nameof(maxValue)} ({maxValue}).");
            }

            // use maxValue + 1 because Rand.Next() range of returned value includes minValue but not maxValue
            return Rand.Next(minValue, maxValue + 1);
        }

        /// <summary>
        /// Wait a specified number of seconds before returning from the method.
        /// </summary>
        /// <param name="n">Wait time in seconds</param>
        /// <returns>void</returns>
        public static void WaitNSeconds(int n)
        {
            Thread.Sleep(n * 1000);
        }
    }
}
