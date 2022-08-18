using Agency.Core.Contracts;
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
        public ICargoShip GetCargoShip(Guid index)
        {
            return _service.GetCargoShip(index);
        }
        [HttpGet("GetAllCargoShips")]
        public List<CargoShip> GetAllVehicles()
        {
            return _service.GetCargoShips();
        }

        [HttpPost("CreateCargoShip")]
        public bool CreateCargoShip([FromBody] CargoShip cargoShip)
        {
            if (cargoShip.ClassType != Models.Enums.VehicleClassType.CargoShip)
            {
                return false;
            }
            if (cargoShip.Type != Models.Vehicles.Enums.VehicleType.Sea)
            {
                return false;
            }
            _service.AddCargoShip(cargoShip);
            return true;
        }
    }
}
