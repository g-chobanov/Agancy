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
        public async Task<CargoShipDTO> GetCargoShip(Guid index)
        {
            return await _service.GetCargoShipAsync(index);
        }
        [HttpGet("GetAllCargoShips")]
        public async Task<List<CargoShipDTO>> GetAllCargoShips()
        {
            return await _service.GetCargoShipsAsync();
        }

        [HttpPost("CreateCargoShip")]
        public async Task<CargoShipDTO> CreateCargoShip([FromBody] CargoShipDTO cargoShip)
        {
           return await _service.CreateCargoShipAsync(cargoShip);
        }

        [HttpDelete("DeleteCargoShip")]
        public async Task DeleteCargoShip(Guid index)
        {
            await _service.DeleteCargoShipAsync(index);
        }

        [HttpPut("UpdateCargoShip")]
        public async Task<CargoShipDTO> UpdateCargoShip([FromBody] CargoShipDTO cargoShip)
        {
           return await _service.UpdateCargoShipAsync(cargoShip);
        }
    }
}
