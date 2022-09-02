using Agency.Core.Contracts;
using Agency.Models.Classes;
using Agency.Models.Contracts;
using Agency.Models.DTOs;
using Agency.Models.Vehicles.Contracts;
using Microsoft.AspNetCore.Mvc;
namespace Agency.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class JourneyController : ControllerBase
    {
        private readonly IJourneyService _service;
        public JourneyController(IJourneyService journeyService)
        {
            _service = journeyService;
        }

        [HttpGet("GetJourney")]
        public async Task<JourneyDTO> GetJourney(Guid id)
        {
            return await _service.GetJourneyAsync(id);
        }

        [HttpGet("GetAllJourneys")]
        public async Task<List<JourneyDTO>> GetAllJourneys()
        {
            return await _service.GetJourneysAsync();
        }
        [HttpGet("GetJourneyStringInfo")]
        public async Task<string> GetJourneyStringInfo(Guid id)
        {
            return await _service.GetJourneyStringInfoAsync(id);
        }
        [HttpPost("CreateJourney")]
        public async Task<JourneyDTO> CreateJourney([FromBody] JourneyDTO journey)
        {
            return await _service.CreateJourneyAsync(journey);
        }
        [HttpDelete("DeleteJourney")]
        public async Task DeleteJourney(Guid index)
        {
            await _service.DeleteJourneyAsync(index);
        }
        [HttpPut("UpdateJourney")]
        public async Task<JourneyDTO> UpdateJourney([FromBody] JourneyDTO journey)
        {
            return await _service.UpdateJourneyAsync(journey);
        }
        [HttpGet("GetTravelCosts")]
        public async Task<decimal> GetTravelCosts(Guid id)
        {
             return await _service.GetTravelCostsAsync(id);
        }
    }
    
}
