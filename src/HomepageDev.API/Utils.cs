using System;
using System.Linq;

namespace HomepageDev.API
{
    public static class Utils
    {
        private static readonly Random Rand = new Random();

        public static string GenerateRandomString(int length)
        {
            return new string(
                Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789", length)
                .Select(s => s[Rand.Next(s.Length)])
                .ToArray()
            );
        }

        public static int GenerateRandomInteger(int minValue, int maxValue)
        {
            if (minValue > maxValue)
            {
                throw new ArgumentOutOfRangeException($"minValue ({minValue}) cannot be greater than maxValue ({maxValue}).");
            }

            return Rand.Next(minValue, maxValue + 1);
        }
    }
}
