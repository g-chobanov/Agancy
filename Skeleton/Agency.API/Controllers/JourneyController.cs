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
        public async Task<ActionResult<JourneyDTO>> GetJourney(Guid id)
        {
            try
            {
                return Ok(await _service.GetJourneyAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAllJourneys")]
        public async Task<ActionResult<List<JourneyDTO>>> GetAllJourneys()
        {
            try
            {
                return Ok(await _service.GetJourneysAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetJourneyStringInfo")]
        public async Task<ActionResult<string>> GetJourneyStringInfo(Guid id)
        {
            try
            {
                return Ok(await _service.GetJourneyStringInfoAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("CreateJourney")]
        public async Task<ActionResult<JourneyDTO>> CreateJourney([FromBody] JourneyDTO journey)
        {
            try
            {
                return Ok(await _service.CreateJourneyAsync(journey));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("DeleteJourney")]
        public async Task<ActionResult> DeleteJourney(Guid index)
        {
            try
            {
                await _service.DeleteJourneyAsync(index);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("UpdateJourney")]
        public async Task<ActionResult<JourneyDTO>> UpdateJourney([FromBody] JourneyDTO journey)
        {
            try
            {
                return Ok(await _service.UpdateJourneyAsync(journey));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetTravelCosts")]
        public async Task<ActionResult<decimal>> GetTravelCosts(Guid id)
        {
            try
            {
                return Ok(await _service.GetTravelCostsAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
    
}
