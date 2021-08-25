using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using HomepageDev.Models;
using Microsoft.AspNetCore.Mvc;

namespace HomepageDev.API.Controllers
{
    /// <summary>
    /// This class contains methods to fetch mock/test data to use when testing other applications.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class MockDataController : ControllerBase
    {
        private const int MaxRandomPoints = 100;
        private const double PhxMinLat = 33.19;
        private const double PhxMaxLat = 33.66;
        private const double PhxMinLon = -112.30;
        private const double PhxMaxLon = -111.59;

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="numPoints">The number of random lat,lon points to be returned</param>
        /// <response code="200"></response>
        /// <response code="400"></response>
        [HttpGet]
        [Route("RandomPointsPhx")]
        public ObjectResult RandomPointsPhx(int numPoints)
        {
            if (numPoints <= 0 || numPoints > MaxRandomPoints)
            {
                return BadRequest($"Value of parameter {nameof(numPoints)} ({numPoints}) must be greater than 0 and less than or equal to {MaxRandomPoints}.");
            }
            
            var mapLocations = new List<MapLocation>();

            for (var i = 0; i < numPoints; i++)
            {
                mapLocations.Add(new MapLocation(
                    $"Random location {i + 1}",
                    Utils.MiscUtils.GenerateRandomDecimal(PhxMinLat, PhxMaxLat),
                    Utils.MiscUtils.GenerateRandomDecimal(PhxMinLon, PhxMaxLon))
                );
            }
            
            return Ok(mapLocations);
        }
    }
}