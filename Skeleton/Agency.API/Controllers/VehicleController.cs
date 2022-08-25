using Agency.Core.Contracts;
using Agency.Models.Models.Vehicles;
using Agency.Models.Vehicles.Contracts;
using Agency.Models.Vehicles.Enums;
using Microsoft.AspNetCore.Mvc;
namespace Agency.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehicleController : ControllerBase
    {
        //private string createCommand = "createbus";
        private readonly IVehicleService _service;
        public VehicleController(IVehicleService service)
        {
            _service = service;
        }

        [HttpGet("GetVehicle")]
        public IVehicle GetVehicle(Guid index)
        {
            return _service.GetVehicle(index);
        }

        [HttpGet("GetAllVehicles")]
        public List<IVehicle> GetAllVehicles()
        {
            return _service.GetVehicles();
        }

        [HttpGet("GetVehiclesByType")]
        public List<Vehicle> GetAllVehiclesByType(VehicleType type)
        {
            return _service.GetVehiclesByType(type);
        }

    }
}
