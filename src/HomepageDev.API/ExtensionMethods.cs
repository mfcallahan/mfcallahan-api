using System.Collections.Generic;

namespace HomepageDev.API
{
    /// <summary>
    /// Class to house custom extension methods created for this solution
    /// </summary>
    public static class ExtensionMethods
    {
        /// <summary>
        /// Add a key/value pair to an IDictionary&lt;TKey, TValue&gt; if the value is not null.
        /// </summary>
        /// <typeparam name="TKey">The type of the IDictionary key</typeparam>
        /// <typeparam name="TValue">The type of the IDictionary value</typeparam>
        /// <param name="dictionary">The IDictionary to which the key/value pair will be added if the value is not null</param>
        /// <param name="key">IDictionary key</param>
        /// <param name="value">IDictionary value</param>
        public static void AddIfNotNull<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue value)
        {
            if (value != null)
            {
                dictionary.Add(key, value);
            }
        }
    }
}
