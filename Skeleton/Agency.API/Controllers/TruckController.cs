using Agency.Core.Contracts;
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
        public ITruck GetTruck(Guid index)
        {
            return _service.GetTruck(index);
        }

        [HttpGet("GetAllTrucks")]
        public List<Truck> GetAllTrucks()
        {
            return _service.GetTrucks();
        }

        [HttpPost("CreateTruckJSON")]
        public bool CreateTruckJSON([FromBody] Truck Truck)
        {
            if (Truck.ClassType != Models.Enums.VehicleClassType.Truck)
            {
                return false;
            }
            if (Truck.Type != Models.Vehicles.Enums.VehicleType.Land)
            {
                return false;
            }
            _service.AddTruck(Truck);
            return true;
        }

        
    }
}
