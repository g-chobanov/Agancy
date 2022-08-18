using Agency.Core.Contracts;
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
        public BusController(IBusService service)
        {
            _service = service;
        }

        [HttpGet("GetBus")]
        public IBus GetBus(Guid index)
        {
            return _service.GetBus(index);
        }
        [HttpGet("GetAllBuses")]
        public List<Bus> GetAllVehicles() 
        {
            return _service.GetBuses();
        }

        [HttpPost("CreateBus")]
        public bool CreateBus([FromBody] Bus bus)
        {
            if (bus.ClassType != Models.Enums.VehicleClassType.Bus)
            {
                return false;
            }
            if (bus.Type != Models.Vehicles.Enums.VehicleType.Land)
            {
                return false;
            }
            _service.AddBus(bus);
            return true;
        }
    }
}
