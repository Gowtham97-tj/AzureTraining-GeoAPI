using GeoAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        [HttpGet("states/{stateId}/cities")]
        public IActionResult GetCities(int stateId)
        {
            var result = _citiesList
            .Where(c => c.StateId == stateId)
            .Select(c => new { c.Id, c.Name })
            .ToList();

            if (result.Count == 0)
                return NotFound(new { message = "No cities found for this stateId" });

            return Ok(result);
        }

        private static readonly List<City> _citiesList = new()
        {
            new City { Id = 1,  Name = "Chennai",     StateId = 1 },
            new City { Id = 2,  Name = "Coimbatore",  StateId = 1 },
            new City { Id = 3,  Name = "Madurai",     StateId = 1 },

            new City { Id = 4,  Name = "Mumbai",      StateId = 2 },
            new City { Id = 5,  Name = "Pune",        StateId = 2 },
            new City { Id = 6,  Name = "Nagpur",      StateId = 2 },

            new City { Id = 7,  Name = "Bengaluru",   StateId = 3 },
            new City { Id = 8,  Name = "Mysuru",      StateId = 3 },
            new City { Id = 9,  Name = "Mangaluru",   StateId = 3 }
        };
    }
}
