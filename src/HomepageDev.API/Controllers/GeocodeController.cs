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
        /// Returns an object with the best matched output addresss and lat/lon coordinates for the input address. All parameters
        /// are optional, but the request must have a value for at least one parameter.
        /// </remarks>
        [HttpGet]
        [Route("SingleAddress")]
        public async Task<ObjectResult> SingleAddress(
            int foo,
            string address = null,
            string city = null,
            string stateProvince = null,
            string postalCode = null,
            string country = null
        )
        {
            var x = 1 / foo;
            if (address == null && city == null && stateProvince == null && postalCode == null && country == null)
            {
                throw new ArgumentException("At least one parameter must have a value.");
            }
            try
            {
                return Ok(await BingGeocoder.GeocodeAddressAsync(address, city, stateProvince, postalCode, country).ConfigureAwait(false));
            }
            catch (Exception ex)
            {
                return BadRequest("OMG Exception!");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Geocode a batch of addresses.
        /// </summary>
        /// <remarks>
        /// Not yet implemented.
        /// </remarks>
        [HttpPost]
        [Route("BatchAddress")]
        public async Task<ObjectResult> BatchAddress()
        {
            throw new NotImplementedException();
        }
    }
}
