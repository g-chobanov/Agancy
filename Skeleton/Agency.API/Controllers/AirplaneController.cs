using Agency.Core.Contracts;
using Agency.Models.DTOs;
using Agency.Models.Enums;
using Agency.Models.Vehicles;
using Agency.Models.Vehicles.Contracts;
using Agency.Models.Vehicles.Enums;
using Microsoft.AspNetCore.Mvc;
namespace Agency.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AirplaneController : ControllerBase
    {
        private readonly IAirplaneService _service;
        public AirplaneController(IAirplaneService service)
        {
            _service = service;
        }

        [HttpGet("GetAirplane")]
        public async Task<ActionResult<AirplaneDTO>> GetAirplane(Guid index)
        {
            try
            {
                return Ok(await _service.GetAirplaneAsync(index));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetAllAirplanes")]
        public async Task<ActionResult<List<AirplaneDTO>>> GetAllAirplanes()
        {
            try
            {
                return Ok(await _service.GetAirplanesAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("CreateAirplane")]
        public async Task<ActionResult<AirplaneDTO>> CreateAirplane([FromBody] AirplaneDTO airplane)
        {
            try
            {
                return Ok(await _service.CreateAirplaneAsync(airplane));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteAirplane")]
        public async Task<ActionResult> DeleteAirplane(Guid index)
        {
            try
            {
                await _service.DeleteAirplaneAsync(index);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPut("UpdateAirplane")]
        public async Task<ActionResult<AirplaneDTO>> UpdateAirplane([FromBody] AirplaneDTO airplane)
        {
            try
            {
                return Ok(await _service.UpdateAirplaneAsync(airplane));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
