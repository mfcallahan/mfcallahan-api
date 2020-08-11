namespace HomepageDev.API.Models.Bing
{

    /// <summary>
    /// Use the Options Pattern described here to provide strongly typed access to groups of related settings in appsettings.json:
    /// https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/options?view=aspnetcore-3.1
    /// </summary>
    public class BingOptions
    {
        public string ApiKey { get; set; }
        public string ApiRootUrl { get; set; }
        public string GeocodeSingleAddressEndpoint { get; set; }
        public int MaxResults { get; set; }
        public int IncludeNeighborhood { get; set; }
    }
}
