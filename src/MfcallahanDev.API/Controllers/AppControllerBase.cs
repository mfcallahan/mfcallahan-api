using Microsoft.AspNetCore.Mvc;

namespace MfcallahanDev.API.Controllers
{
    [Route("api")]
    [ApiController]
    public abstract class AppControllerBase : ControllerBase
    {
        private protected string Foo;

        public AppControllerBase()
        {
            Foo = "Bar";
        }

        [HttpGet]
        [Route("Hello")]
        public ObjectResult Hello()
        {
            return Ok($"Hello, the server at {Request.Host} is responding.");
        }
    }
}
