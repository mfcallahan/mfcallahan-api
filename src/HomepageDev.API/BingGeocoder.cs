using HomepageDev.API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomepageDev.API
{
    public class BingGeocoder : IBingGeocoder
    {
        private IHttpClientWrapper HttpClientWrapper { get; }

        public BingGeocoder(IHttpClientWrapper httpClientWrapper)
        {
            HttpClientWrapper = httpClientWrapper;
        }

        public void GeocodeAddress(string address, string city, string state, string zipCode)
        {

        }
    }
}
