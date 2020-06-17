using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace HomepageDev.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilsController : AppControllerBase
    {
        private const int RandomStringMaxLength = 100;
        private readonly Random Rand = new Random();

        public UtilsController() : base() { }

        [HttpGet]
        [Route("RandomString")]
        public ObjectResult RandomString(int length)
        {
            try
            {
                if (length <= 0 || length > RandomStringMaxLength)
                {
                    return BadRequest($"Value of parameter 'length' must be greater than 0 and less than or equal to {RandomStringMaxLength}.");
                }

                const string charSet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

                var randomString = new string(
                    Enumerable.Repeat(charSet, length)
                    .Select(s => s[Rand.Next(s.Length)])
                    .ToArray()
                );

                return Ok(randomString);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("RandomInt")]
        public ObjectResult RandomInt(int minValue, int maxValue)
        {
            try
            {
                return Ok(Rand.Next(minValue, maxValue));
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
