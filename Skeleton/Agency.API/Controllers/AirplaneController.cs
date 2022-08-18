using Agency.Core.Contracts;
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
        public IAirplane GetAirplane(Guid index)
        {
            return _service.GetAirplane(index);
        }
        //change it later
        [HttpGet("GetAllAirplanes")]
        public List<Airplane> GetAllAirplanes()
        {
            return _service.GetAirplanes();
        }

        [HttpPost("CreateAirplane")]
        public bool CreateAirplane([FromBody] Airplane airplane)
        {
            if (airplane.ClassType != VehicleClassType.Airplane)
            {
                return false;
            }
            if (airplane.Type != VehicleType.Air)
            {
                return false;
            }
            _service.AddAirplane(airplane);
            return true;
        }
        //delete airplane
    }
}
