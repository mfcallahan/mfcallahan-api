using Microsoft.AspNetCore.Mvc;
using System;
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
        private const int RandomStringMaxLength = 100; //TODO: set this in config file?

        /// <summary>
        /// Verify server is responding.
        /// </summary>
        /// <remarks>
        /// Returns a message indicating the server name and that it is responding.
        /// </remarks>
        [HttpGet]
        [HttpPost]
        [Route("Hello")]
        public ObjectResult Hello()
        {
            return Ok($"Hello, the server at {Request.Host} is responding.");
        }

        /// <summary>
        /// Generate a random string containing letters A-Z (upper and lower case) and numbers 0-9.
        /// </summary>
        /// <remarks>
        /// Returns a random string of the specified length.
        /// </remarks>
        /// <param name="length">The desired length of the random string</param>
        [HttpGet]
        [Route("RandomString")]
        public ObjectResult RandomString(int length)
        {
            try
            {
                if (length <= 0 || length > RandomStringMaxLength)
                {
                    return BadRequest($"Value of parameter 'length' ({length}) must be greater than 0 and less than or equal to {RandomStringMaxLength}.");
                }

                return Ok(Utils.GenerateRandomString(length));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Generate a random integer.
        /// </summary>
        /// <remarks>
        /// Returns a random integer with a value between the specified inclusive lower and upper bounds.
        /// </remarks>
        /// <param name="minValue">Lower bound</param>
        /// <param name="maxValue">Upper bound</param>
        [HttpGet]
        [Route("RandomInt")]
        public ObjectResult RandomInt(int minValue, int maxValue)
        {
            try
            {
                return Ok(Utils.GenerateRandomInteger(minValue, maxValue));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
