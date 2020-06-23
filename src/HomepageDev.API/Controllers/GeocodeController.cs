using HomepageDev.API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HomepageDev.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeocodeController : ControllerBase
    {
        private IAppSettings AppSettings { get; }
        private IBingGeocoder BingGeocoder { get; }

        public GeocodeController(IAppSettings appSettings, IBingGeocoder bingGeocoder)
        {
            AppSettings = appSettings;
            BingGeocoder = bingGeocoder;
        }

        /// <summary>
        /// Geocode a single address.
        /// </summary>
        /// <remarks>
        /// Not implemented.
        /// </remarks>
        [HttpGet]
        [Route("SingleAddress")]
        public ObjectResult SingleAddress(string address, string city, string state, string zipCode)
        {
            throw new NotImplementedException();
            BingGeocoder.GeocodeAddress(address, city, state, zipCode);
        }
    }
}
