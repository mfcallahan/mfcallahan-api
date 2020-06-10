using Microsoft.AspNetCore.Mvc;

namespace HomepageDev.API.Controllers
{
    [ApiController]
    [Route("api")]
    public class GeocodeController : AppControllerBase
    {
        public GeocodeController() : base() { }

        [Route("GeocodeAddress")]
        public ObjectResult GeocodeAddress()
        {
            return Ok("0, 0");
        }
    }
}
