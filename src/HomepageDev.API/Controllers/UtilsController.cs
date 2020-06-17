using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics.CodeAnalysis;

namespace HomepageDev.API.Controllers
{
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Route("api/[controller]")]
    public class UtilsController : AppControllerBase
    {
        private const int RandomStringMaxLength = 100;

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

                return Ok(Utils.GenerateRandomString(length));
            }
            catch (Exception ex)
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
                return Ok(Utils.GenerateRandomInteger(minValue, maxValue));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
