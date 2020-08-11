using System.Collections.Specialized;

namespace HomepageDev.API
{
    /// <summary>
    /// Class to house custom extension methods created for this solution
    /// </summary>
    public static class ExtensionMethods
    {
        /// <summary>
        /// Add a name/value pair to a NameValueCollection if the value is not null.
        /// </summary>
        /// <param name="nameValueCollection">The NameValueCollection to which the name/value pair will be added if the value is not null</param>
        /// <param name="name">The string name of the entry to add.</param>
        /// <param name="value">The string key of the entry to add.</param>
        public static void AddIfNotNull(this NameValueCollection nameValueCollection, string name, string value)
        {
            if (value != null)
            {
                nameValueCollection.Add(name, value);
            }
        }
    }
}
