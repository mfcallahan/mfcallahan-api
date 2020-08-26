using HomepageDev.Models.ApiResponses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Diagnostics;

namespace HomepageDev.API.Controllers
{
    /// <summary>
    /// Custom Controller error handling
    /// </summary>
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : ControllerBase
    {
        /// <summary>
        /// Return a custom error response which includes user-friendly information, but excludes the full stack trace.
        /// </summary>
        /// <returns>ErrorResponse</returns>
        [Route("/error")]
        public ErrorResponse Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context?.Error;
            // Internal Server Error is default code
            var code = 500;

            if (
                exception is System.InvalidOperationException ||
                exception is System.ArgumentException ||
                exception is System.ArgumentOutOfRangeException
            )
            {
                code = 400;
            }
            else if (exception is System.NotImplementedException)
            {
                code = 501;
            }

            Response.StatusCode = code;

            return new ErrorResponse(code, exception);
        }
    }
}
