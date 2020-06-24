using HomepageDev.API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HomepageDev.API
{
    public class BingGeocoder : IBingGeocoder
    {
        private IAppSettings AppSettings { get; }
        private IHttpClientWrapper HttpClientWrapper { get; }

        public BingGeocoder(IAppSettings appSettings, IHttpClientWrapper httpClientWrapper)
        {
            HttpClientWrapper = httpClientWrapper;
            AppSettings = appSettings;
        }

        public async Task GeocodeAddress(string address, string city, string state, string zipCode)
        {
            throw new NotImplementedException();
            var requestParams = GetDefaultBingParams();
            //requestParams.Add();

            var requestUri = new Uri(AppSettings.BingApiKey + AppSettings.BingGeocodeSingleAddressEndpoint);
            HttpResponseMessage response = await HttpClientWrapper.GetAsync(requestUri).ConfigureAwait(false);
        }

        private Dictionary<string, string> GetDefaultBingParams()
        {
            return new Dictionary<string, string>() { { "key", AppSettings.BingApiKey } };
        }
    }
}
