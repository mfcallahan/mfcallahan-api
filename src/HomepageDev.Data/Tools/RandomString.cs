using System.Security.Cryptography;
using System.Text;

namespace HomepageDev.Data
{
    public static class RandomString
    {
        // generate a cryptographically secure random string
        public static string GenerateRandomString(int len, bool useNums)
        {
            byte[] data = new byte[1];
            char[] chars = null;

            if (useNums)
            {
                chars = new char[62];
                chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();
            }
            else
            {
                chars = new char[52];
                chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            }

            // RNGCryptoServiceProvider Class: Implements a cryptographic Random Number Generator (RNG) using
            // the implementation provided by the cryptographic service provider (CSP).
            // https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.rngcryptoserviceprovider

            using (RNGCryptoServiceProvider c = new RNGCryptoServiceProvider())
            {
                c.GetNonZeroBytes(data);
                data = new byte[len];
                c.GetNonZeroBytes(data);
            }

            StringBuilder result = new StringBuilder(len);
            foreach (byte b in data)
                result.Append(chars[b % (chars.Length)]);

            return result.ToString();
        }
    }
}
