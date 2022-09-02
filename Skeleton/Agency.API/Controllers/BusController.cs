using Agency.Core.Contracts;
using Agency.Models.DTOs;
using Agency.Models.Vehicles;
using Agency.Models.Vehicles.Contracts;
using Microsoft.AspNetCore.Mvc;
namespace Agency.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BusController : ControllerBase
    {
        private readonly IBusService _service;
        public BusController (IBusService service)
        {
            _service = service;
        }

        [HttpGet("GetBus")]
        public async Task<ActionResult<BusDTO>> GetBus(Guid index)
        {
            try
            {
                return Ok(await _service.GetBusAsync(index));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAllBuses")]
        public async Task<ActionResult<List<BusDTO>>> GetAllBuses()
        {
            try
            {
                return Ok(await _service.GetBusesAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("CreateBus")]
        public async Task<ActionResult<BusDTO>> CreateBus([FromBody] BusDTO bus)
        {
            try
            {
                return Ok(await _service.CreateBusAsync(bus));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteBus")]
        public async Task<ActionResult> DeleteBus(Guid index)
        {
            
            try
            {
                await _service.DeleteBusAsync(index);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateBus")]
        public async Task<ActionResult<BusDTO>> UpdateBus([FromBody] BusDTO bus)
        {
            try
            {
                return Ok(await _service.UpdateBusAsync(bus));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
