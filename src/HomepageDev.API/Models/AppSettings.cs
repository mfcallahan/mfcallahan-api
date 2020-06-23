using HomepageDev.API.Interfaces;

namespace HomepageDev.API.Models
{
    public class AppSettings : IAppSettings
    {
        public string BingApiKey { get; set; }
    }
}
