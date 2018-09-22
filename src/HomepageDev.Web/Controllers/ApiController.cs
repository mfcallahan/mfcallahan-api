﻿using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Web.Http;
using HomepageDev.Data.POCOs;
using HomepageDev.Data.Apis;

namespace HomepageDev.Web.Controllers
{
    public class DevApiController : ApiController
    {
        /// <summary>
        /// Returns information about the author of this website.
        /// </summary>
        /// <hello>
        ///  Hi! If you're looking through my code right now, you obviously have the same 
        ///  passion for software development as I do.  Cool, hit me up: matthew.callahan@outlook.com
        /// </hello>
        [HttpGet]
        [Route("api/Hello")]
        public HelloResponse Hello()
        {
            return new HelloResponse("200", "Hello. The API at mfcallahan.com is responding.");
        }

        /// <summary>
        /// Returns a string of random charcaters 
        /// </summary>
        /// <param name="length">The desired length of the random string</param>
        /// <param name="useNums">Use numerical chars in the random string</param>
        [HttpGet]
        [Route("api/RandomString")]
        public string RandomString(int length, bool useNums = true)
        {
            if (length < 0)
                length = 0;

            if (length > 100)
                length = 100;

            return HomepageDev.Data.Tools.RandomString.GenerateRandomString(length, useNums);
        }


        /// <summary>
        /// Locates a single input address, returning coordinates of the address as
        /// well as information about the accuracy of the output location.
        /// </summary>
        /// <param name="address">The input address, ex: 703 E Johnson St</param>
        /// <param name="city">The input city, ex: Madison</param>
        /// <param name="stateProv">The input city, ex: Wisconsin</param>
        /// <param name="postalCode">The input city, ex: 53703</param>
        /// <param name="country">The input city, ex: USA</param>
        [HttpGet]
        [Route("api/Geocode")]
        public InputAdr Geocode(string address = "", string city = "", string stateProv = "", string postalCode = "", string country = "")
        {
            InputAdr inputAdr = new InputAdr(address, city, stateProv, postalCode, country);

            BingGeocoder bing = new BingGeocoder();
            bing.GeocodeAddress(inputAdr);

            return inputAdr;
        }

        /// <summary>
        /// Returns information about an IP address
        /// </summary>
        /// <param name="ipAdr">The input IP address</param>
        [HttpGet]
        [Route("api/IpInfo")]
        public IpDataResponse IpInfo(string ipAdr)
        {
            return IpDataApi.GetIpInfo(ipAdr);
        }

        /// <summary>
        /// Returns a delayed string response from the server, pausing for waitSeconds
        /// </summary>
        /// /// <param name="waitSeconds">The number seconds the server will wait before responding. (min 0, max 10)</param>
        [HttpGet]
        [Route("api/GetDelayedResponse")]
        public string GetDelayedResponse(int waitSeconds = 0)
        {
            if (waitSeconds < 0)
                waitSeconds = 0;

            if (waitSeconds > 10)
                waitSeconds = 10;

            Thread.Sleep(waitSeconds * 1000);

            return "The server waited for " + waitSeconds + " seconds.";
        }

        static StringContent SerializeApiResponse<T>(T obj)
        {
            return new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
        }
    }
}
