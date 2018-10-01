using HomepageDev.Geocoder.Enums;
using HomepageDev.Geocoder.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace HomepageDev.Geocoder.Controllers
{
    [Route("api")]
    public class GeocoderController : ApiController
    {
        [Route("geocode")]
        public InputAddress Geocode(
            string address = "", 
            string city = "", 
            string stateProv = "", 
            string postalCode = "", 
            string country = "", 
            string source = "")
        {
            if (!string.IsNullOrEmpty(source) && !SourceExists(source))
            {
                // return source does not exist error
            }

            var inputAdrs = new List<InputAddress>
            {
                new InputAddress(address, city, stateProv, postalCode, country)
            };

            var geocoder = new HomepageDev.Geocoder.ApplicationLogic.Geocoder(inputAdrs);

            try
            {
                geocoder.GetGeocodeResultsAsync();
            }
            catch (Exception ex)
            {
                //return internal server error
                //this.Request.CreateErrorResponse();
            }

            //return geocded adrs

            return null;
        }

        private bool SourceExists(string source)
        {
            return Enum.GetNames(typeof(GeocodeSources)).Contains(source);
        }
    }
}
