using Microsoft.AspNetCore.Mvc;
using System;

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
            throw new NotImplementedException();
            //return Ok("0, 0");
        }
    }
}
