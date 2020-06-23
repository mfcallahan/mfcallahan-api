using HomepageDev.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HomepageDev.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeocodeController : ControllerBase
    {
        private IAppSettings AppSettings { get; }

        public GeocodeController(IAppSettings appSettings)
        {
            AppSettings = appSettings;
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
            //throw new NotImplementedException();
            return Ok($"AppSettings.BingApiKey: {AppSettings.BingApiKey}");
        }
    }
}
