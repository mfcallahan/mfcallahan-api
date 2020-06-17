//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Diagnostics.CodeAnalysis;

//namespace HomepageDev.API.Controllers
//{
//    [ExcludeFromCodeCoverage]
//    [ApiController]
//    [Route("api/[controller]")]
//    public class GeocodeController : AppControllerBase
//    {
//        public GeocodeController() : base() { }

//        [Route("SingleAddress")]
//        public ObjectResult SingleAddress(string address = null, string city = null, string state = null, string zip = null)
//        {
//            if (
//                string.IsNullOrEmpty(address) &&
//                string.IsNullOrEmpty(city) &&
//                string.IsNullOrEmpty(state) &&
//                string.IsNullOrEmpty(zip)
//            )
//            {
//                return BadRequest("All parameters cannot be null or empty.");
//            }

//            throw new NotImplementedException();
//            //return Ok("0, 0");
//        }
//    }
//}
