using HomepageDev.API.Models.ApiResponses;
using HomepageDev.API.Models.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace HomepageDev.API.Controllers
{
    /// <summary>
    /// This class contains simple utility API methods to demonstrate implementation of a .NET Core Controller class using
    /// attribute routing and Swagger API documentation configuration.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Route("api/[controller]")]
    public class UtilsController : ControllerBase
    {
        private readonly AppOptions AppOptions;
        private const int RandomStringMaxLength = 100; // TODO: set this in config file?
        private const int MaxWaitTimeSeconds = 10; // TODO: set this in config file?

        public UtilsController(IOptions<AppOptions> appOptions)
        {
            AppOptions = appOptions?.Value;
        }

        /// <summary>
        /// Verify server is responding.
        /// </summary>
        /// <remarks>
        /// Returns an object indicating the current app configuration and a messgae with server name.
        /// </remarks>
        /// <response code="200">The server is responding.</response>
        [HttpGet]
        [HttpPost]
        [Route("Hello")]
        public ObjectResult Hello()
        {
            return Ok(new HelloResponse(AppOptions.Configuration, $"Hello, the server at {Request.Host} is responding."));
        }

        /// <summary>
        /// Generate a random string containing letters A-Z (upper and lower case) and numbers 0-9.
        /// </summary>
        /// <remarks>
        /// Returns a random string of the specified length.
        /// </remarks>
        /// <param name="length">The desired length of the random string.</param>
        /// <response code="200">A random string.</response>
        /// <response code="400">The value of parameter 'length' is invalid.</response>
        [HttpGet]
        [Route("RandomString")]
        public ObjectResult RandomString(int length)
        {
            if (length <= 0 || length > RandomStringMaxLength)
            {
                return BadRequest($"Value of parameter {nameof(length)} ({length}) must be greater than 0 and less than or equal to {RandomStringMaxLength}.");
            }

            return Ok(Utils.GenerateRandomString(length));
        }

        /// <summary>
        /// Generate a random integer.
        /// </summary>
        /// <remarks>
        /// Returns a random integer with a value between the specified inclusive lower and upper bounds.
        /// </remarks>
        /// <param name="minValue">Lower bound</param>
        /// <param name="maxValue">Upper bound</param>
        /// <response code="200">A random integer.</response>
        /// <response code="400">The values of parameters 'minValue' or 'maxValue' are invalid.</response>
        [HttpGet]
        [Route("RandomInt")]
        public ObjectResult RandomInt(int minValue, int maxValue)
        {
            return Ok(Utils.GenerateRandomInteger(minValue, maxValue));
        }

        /// <summary>
        /// Simulate a long-running API request by waiting a sepcified number of seconds before returning a response.
        /// </summary>
        /// <remarks>
        /// Returns a string containing a messgae indicating how long the server waited.
        /// </remarks>
        /// <param name="seconds">Wait time, in seconds.</param>
        /// <response code="200">The server waited the specified number of seconds before returning a response.</response>
        [HttpGet]
        [Route("DelayedResponse")]
        public ObjectResult DelayedResponse(int seconds)
        {
            if (seconds < 0 || seconds > MaxWaitTimeSeconds)
            {
                return BadRequest($"Value of parameter {nameof(seconds)} ({seconds}) must be greater than or equal 0 and less than or equal to {MaxWaitTimeSeconds}.");
            }

            var s = new Stopwatch();
            s.Start();

            Utils.WaitNSeconds(seconds);

            s.Stop();

            return Ok($"Hello, the server at {Request.Host} waited {(decimal)s.ElapsedMilliseconds / (decimal)1000} seconds beore responding.");
        }
    }
}
