using Agency.Core.Contracts;
using Agency.Models.DTOs;
using Agency.Models.Vehicles;
using Agency.Models.Vehicles.Contracts;
using Microsoft.AspNetCore.Mvc;
namespace Agency.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TruckController : ControllerBase
    {
        private readonly ITruckService _service;
        public TruckController(ITruckService service)
        {
            _service = service;
        }

        [HttpGet("GetTruck")]
        public async Task<ActionResult<TruckDTO>> GetTruck(Guid index)
        {
            try
            {
                return Ok(await _service.GetTruckAsync(index));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetAllTrucks")]
        public async Task<ActionResult<List<TruckDTO>>> GetAllTrucks()
        {
            try
            {
                return Ok(await _service.GetTrucksAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("CreateTruck")]
        public async Task<ActionResult<TruckDTO>> CreateTruck([FromBody] TruckDTO truck)
        {
            try
            {
                return Ok(await _service.CreateTruckAsync(truck));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteTruck")]
        public async Task<ActionResult> DeleteTruck(Guid index)
        {
            try
            {
                await _service.DeleteTruckAsync(index);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateTruck")]
        public async Task<ActionResult<TruckDTO>> UpdateTruck([FromBody] TruckDTO truck)
        {
            try
            {
                return Ok(await _service.UpdateTruckAsync(truck));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
