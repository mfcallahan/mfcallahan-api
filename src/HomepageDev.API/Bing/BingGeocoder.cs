using HomepageDev.API.Interfaces;
using HomepageDev.API.Models.ApiResponses;
using HomepageDev.API.Models.Bing;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Specialized;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace HomepageDev.API
{
    /// <summary>
    /// Encapsulates address geocoding services avaialble from in Bing Locations API:
    /// https://docs.microsoft.com/en-us/bingmaps/rest-services/locations/
    /// </summary>
    public class BingGeocoder : IBingGeocoder
    {
        private readonly IHttpClientWrapper HttpClientWrapper;
        private readonly BingOptions BingOptions;

        public BingGeocoder(IHttpClientWrapper httpClientWrapper, IOptions<BingOptions> bingOptions)
        {
            HttpClientWrapper = httpClientWrapper;

            _ = bingOptions ?? throw new ArgumentException($"{nameof(bingOptions)} cannot be null.");
            BingOptions = bingOptions.Value;
        }

        public async Task<SingleAddressResponse> GeocodeAddressAsync(
            string address,
            string city,
            string stateProvince,
            string postalCode,
            string country
        )
        {
            Uri.TryCreate(new Uri(BingOptions.ApiRootUrl), BingOptions.GeocodeSingleAddressEndpoint, out Uri apiUri);

            var uriBuilder = new UriBuilder(apiUri);

            var requestParams = GetDefaultBingParams();
            requestParams.AddIfNotNull("addressLine", address);
            requestParams.AddIfNotNull("locality", city);
            requestParams.AddIfNotNull("adminDistrict", stateProvince);
            requestParams.AddIfNotNull("postalCode", postalCode);
            requestParams.AddIfNotNull("countryRegion", country);

            uriBuilder.Query = requestParams.ToString();

            HttpResponseMessage responseMessage = await HttpClientWrapper.GetAsync(uriBuilder.Uri).ConfigureAwait(false);

            var responseBody = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
            var responseObject = JsonConvert.DeserializeObject<LocationResponse>(responseBody);

            return new SingleAddressResponse()
            {
                OutputFormattedAddress = responseObject.ResourceSets[0].Resources[0].Address.FormattedAddress,
                Latitude = responseObject.ResourceSets[0].Resources[0].GeocodePoints[0].Coordinates[0],
                Longitude = responseObject.ResourceSets[0].Resources[0].GeocodePoints[0].Coordinates[1],
            };
        }

        public async Task GeocodeAddressBacthAsync()
        {
            throw new NotImplementedException();
        }

        //private SingleAddressResponse Foo()
        //{

        //}

        /*
         * Per Bing documentation:
         * 
         * "includeNeighborhood" parameter: Specifies to include the neighborhood in the response when it is available.  Value "1" will
         * include neighborhood information when available, value "0" will not include neighborhood information.
         * 
         * "include" parameter: Specifies additional values to include. The only value for parameter "include" is "ciso2". When
         * you specify include=ciso2, the two-letter ISO country code is included for addresses in the response.
         * 
         * 
         * https://docs.microsoft.com/en-us/bingmaps/rest-services/locations/find-a-location-by-address
         */
        private NameValueCollection GetDefaultBingParams()
        {
            var queryParams = HttpUtility.ParseQueryString(string.Empty);
            queryParams["key"] = BingOptions.ApiKey;
            queryParams["maxResults"] = BingOptions.MaxResults.ToString();
            queryParams["includeNeighborhood"] = BingOptions.IncludeNeighborhood.ToString();
            queryParams["include"] = "ciso2";

            return queryParams;
        }
    }
}
