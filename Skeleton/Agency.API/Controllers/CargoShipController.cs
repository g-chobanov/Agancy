using Agency.Core.Contracts;
using Agency.Models.DTOs;
using Agency.Models.Vehicles;
using Agency.Models.Vehicles.Contracts;
using Microsoft.AspNetCore.Mvc;
namespace Agency.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CargoShipController : ControllerBase
    {
        private readonly ICargoShipService _service;
        public CargoShipController(ICargoShipService service)
        {
            _service = service;
        }

        [HttpGet("GetCargoShip")]
        public async Task<ActionResult<CargoShipDTO>> GetCargoShip(Guid index)
        {
            try
            {
                return Ok(await _service.GetCargoShipAsync(index));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetAllCargoShips")]
        public async Task<ActionResult<List<CargoShipDTO>>> GetAllCargoShips()
        {
            try
            {
                return Ok(await _service.GetCargoShipsAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("CreateCargoShip")]
        public async Task<ActionResult<CargoShipDTO>> CreateCargoShip([FromBody] CargoShipDTO cargoShip)
        {
            try
            {
                return Ok(await _service.CreateCargoShipAsync(cargoShip));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteCargoShip")]
        public async Task<ActionResult> DeleteCargoShip(Guid index)
        {
            try
            {
                await _service.DeleteCargoShipAsync(index);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPut("UpdateCargoShip")]
        public async Task<ActionResult<CargoShipDTO>> UpdateCargoShip([FromBody] CargoShipDTO cargoShip)
        {
            try
            {
                return Ok(await _service.UpdateCargoShipAsync(cargoShip));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
