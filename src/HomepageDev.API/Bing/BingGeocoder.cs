using HomepageDev.API.Interfaces;
using HomepageDev.API.Models.ApiResponses;
using HomepageDev.API.Models.Options;
using HomepageDev.API.Models.Bing;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
            BingOptions = bingOptions?.Value;
        }

        /// <summary>
        /// Geocodes an address using the Bing Maps Locations API
        /// </summary>
        /// <param name="address">Input address</param>
        /// <param name="city">Input city</param>
        /// <param name="stateProvince">Input state or province</param>
        /// <param name="postalCode">Input postal code</param>
        /// <param name="country">Input country</param>
        /// <returns>List&lt;SingleAddressResponse&gt;</returns>
        public async Task<IList<SingleAddressGeocodeResponse>> GeocodeAddressAsync(
            string address = null,
            string city = null,
            string stateProvince = null,
            string postalCode = null,
            string country = null
        )
        {
            _ = Uri.TryCreate(new Uri(BingOptions.ApiRootUrl), BingOptions.GeocodeSingleAddressEndpoint, out Uri apiUri);

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

            return TranslateBingLocationResponse(responseObject);
        }

        public async Task GeocodeAddressBacthAsync()
        {
            throw new NotImplementedException();
        }

        private static List<SingleAddressGeocodeResponse> TranslateBingLocationResponse(LocationResponse response)
        {
            var singleAddressResponses = new List<SingleAddressGeocodeResponse>();

            foreach (var resoure in response.ResourceSets[0].Resources)
            {
                singleAddressResponses.Add(
                    new SingleAddressGeocodeResponse()
                    {
                        OutputAddress = resoure.Address.FormattedAddress,
                        Confidence = resoure.Confidence,
                        MatchType = resoure.Point.Type,
                        //Coordinates are returned as an array: latitude at index 0, longitue at index 1
                        Latitude = resoure.Point.Coordinates[0],
                        Longitude = resoure.Point.Coordinates[1]
                    }
                );
            }

            return singleAddressResponses;
        }

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
