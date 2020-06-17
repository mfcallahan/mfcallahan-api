using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace HomepageDev.API.Controllers
{
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Route("api")]
    public abstract class AppControllerBase : ControllerBase
    {
        private protected string Foo;

        protected AppControllerBase()
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
