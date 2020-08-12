using HomepageDev.API;
using HomepageDev.API.Interfaces;
using HomepageDev.API.Models.ApiResponses;
using HomepageDev.API.Models.Bing;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Threading.Tasks;

namespace HomepageDev.API.Tests.Bing
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class BingGeocoderTests
    {
        [Test]
        [TestCase("742 Evergreen Terrace", "Springfield", "NT", "49007", "USA")]
        public async Task GeocodeAddressAsync_Should_Call_Bing_Locations_API_And_Return_List_Of_SingleAddressResponse(
            string address,
            string city,
            string stateProvince,
            string postalCode,
            string country
        )
        {
            //Arrange
            var mockHttpClientWrapper = new Mock<IHttpClientWrapper>();

            using var mockHttpResponseMessage = new HttpResponseMessage()
            {
                Content = new StringContent(GetMockHttpResponseMessage(out int expectedOutputAddresses))
            };

            mockHttpClientWrapper.Setup(mock => mock.GetAsync(It.IsAny<Uri>())).ReturnsAsync(mockHttpResponseMessage);

            var bingOptions = Options.Create(
                new BingOptions()
                {
                    ApiRootUrl = "https://foo.bar",
                    GeocodeSingleAddressEndpoint = "baz/qux"
                }
            );

            var bingGeocoder = new BingGeocoder(mockHttpClientWrapper.Object, bingOptions);

            //Act
            var result = await bingGeocoder.GeocodeAddressAsync(address, city, stateProvince, postalCode, country).ConfigureAwait(false);

            //Assert
            Assert.That(result is List<SingleAddressGeocodeResponse>);
            Assert.That(result.Count == expectedOutputAddresses);
        }

        private static string GetMockHttpResponseMessage(out int expectedOutputAddresses)
        {
            expectedOutputAddresses = 3;

            //Sample JSON response from Bing Locations API with 3 output addresses
            return "{\"resourceSets\":[{\"estimatedTotal\":3,\"resources\":[{\"__type\":\"\",\"bbox\":[33.444223697365594,-112.0887795397618,33.45194913250695,-112.07643498121506],\"name\":\"700 S 7th Ave, Phoenix, AZ 85007\",\"point\":{\"type\":\"Point\",\"coordinates\":[33.44808641493627,-112.08260726048843]},\"address\":{\"addressLine\":\"700 S 7th Ave\",\"adminDistrict\":\"AZ\",\"adminDistrict2\":\"Maricopa County\",\"countryRegion\":\"United States\",\"formattedAddress\":\"700 S 7th Ave, Phoenix, AZ 85007\",\"locality\":\"Phoenix\",\"neighborhood\":\"Downtown Phoenix\",\"postalCode\":\"85007\",\"countryRegionIso2\":\"US\"},\"confidence\":\"Medium\",\"entityType\":\"Address\",\"geocodePoints\":[{\"type\":\"Point\",\"coordinates\":[33.44808641493627,-112.08260726048843],\"calculationMethod\":\"InterpolationOffset\",\"usageTypes\":[\"Display\"]},{\"type\":\"Point\",\"coordinates\":[33.44808686033335,-112.0825533719425],\"calculationMethod\":\"Interpolation\",\"usageTypes\":[\"Route\"]}],\"matchCodes\":[\"Ambiguous\"]},{\"__type\":\"Location:http://schemas.microsoft.com/search/local/ws/rest/v1\",\"bbox\":[33.436927819957944,-112.07156553101748,33.4446532550993,-112.05922201051536],\"name\":\"700 S 7th St, Phoenix, AZ 85034\",\"point\":{\"type\":\"Point\",\"coordinates\":[33.44079053752862,-112.06539377076642]},\"address\":{\"addressLine\":\"700 S 7th St\",\"adminDistrict\":\"AZ\",\"adminDistrict2\":\"Maricopa County\",\"countryRegion\":\"United States\",\"formattedAddress\":\"700 S 7th St, Phoenix, AZ 85034\",\"locality\":\"Phoenix\",\"neighborhood\":\"Central City\",\"postalCode\":\"85034\",\"countryRegionIso2\":\"US\"},\"confidence\":\"Medium\",\"entityType\":\"Address\",\"geocodePoints\":[{\"type\":\"Point\",\"coordinates\":[33.44079053752862,-112.06539377076642],\"calculationMethod\":\"InterpolationOffset\",\"usageTypes\":[\"Display\"]},{\"type\":\"Point\",\"coordinates\":[33.44079434654014,-112.0653400777894],\"calculationMethod\":\"Interpolation\",\"usageTypes\":[\"Route\"]}],\"matchCodes\":[\"Ambiguous\"]},{\"__type\":\"Location:http://schemas.microsoft.com/search/local/ws/rest/v1\",\"bbox\":[33.44769997905706,-112.07125968791757,33.455425414198416,-112.05891463463973],\"name\":\"700 N 7th St, Phoenix, AZ 85006\",\"point\":{\"type\":\"Point\",\"coordinates\":[33.45156269662774,-112.06508716127865]},\"address\":{\"addressLine\":\"700 N 7th St\",\"adminDistrict\":\"AZ\",\"adminDistrict2\":\"Maricopa County\",\"countryRegion\":\"United States\",\"formattedAddress\":\"700 N 7th St, Phoenix, AZ 85006\",\"locality\":\"Phoenix\",\"neighborhood\":\"Downtown Phoenix\",\"postalCode\":\"85006\",\"countryRegionIso2\":\"US\"},\"confidence\":\"Medium\",\"entityType\":\"Address\",\"geocodePoints\":[{\"type\":\"Point\",\"coordinates\":[33.45156269662774,-112.06508716127865],\"calculationMethod\":\"InterpolationOffset\",\"usageTypes\":[\"Display\"]},{\"type\":\"Point\",\"coordinates\":[33.45156213572543,-112.06514105043512],\"calculationMethod\":\"Interpolation\",\"usageTypes\":[\"Route\"]}],\"matchCodes\":[\"Ambiguous\"]}]}]}";
        }
    }
}
