using HomepageDev.API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HomepageDev.API.Controllers
{
    /// <summary>
    /// This class contains API methods to geocode addresses.  Geocoding is the process of assigning map coordinates
    /// to a descriptive location like an address.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class GeocodeController : ControllerBase
    {
        private IBingGeocoder BingGeocoder { get; }

        public GeocodeController(IBingGeocoder bingGeocoder)
        {
            BingGeocoder = bingGeocoder;
        }

        /// <summary>
        /// Geocode a single address.
        /// </summary>
        /// <remarks>
        /// Not yet implemented.
        /// </remarks>
        [HttpGet]
        [Route("SingleAddress")]
        public async Task<ObjectResult> SingleAddress(string address, string city, string stateProvince, string postalCode, string country)
        {
            try
            {
                await BingGeocoder.GeocodeAddressAsync(address, city, stateProvince, postalCode, country).ConfigureAwait(false);
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
