namespace HomepageDev.API.Interfaces
{
    public interface IAppSettings
    {
        string BingApiRootUrl { get; set; }
        string BingApiKey { get; set; }
        string BingGeocodeSingleAddressEndpoint { get; set; }
    }
}
