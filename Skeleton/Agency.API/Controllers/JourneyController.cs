using Agency.Core.Contracts;
using Agency.Models.Classes;
using Agency.Models.Contracts;
using Agency.Models.Vehicles.Contracts;
using Microsoft.AspNetCore.Mvc;
namespace Agency.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class JourneyController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;
        private readonly IJourneyService _journeyService;
        public JourneyController(IVehicleService vehicleService, IJourneyService journeyService)
        {
            _vehicleService = vehicleService;
            _journeyService = journeyService;
        }

        [HttpGet("GetJourney")]
        public IJourney GetJourney(Guid id)
        {
            return _journeyService.GetJourney(id);
        }

        [HttpGet("")]
        public List<IJourney> GetAllJourneys()
        {
            return _journeyService.GetJourneys();
        }
        [HttpPost("CreateJourney")]
        public bool CreateJourney([FromBody] Journey journey, Guid vehicleID)
        {
            IVehicle vehicle = _vehicleService.GetVehicle(vehicleID);
            if (vehicle == null)
            {
                return false;
            }
            journey.Vehicle = vehicle;
            _journeyService.AddJourney(journey);
            return true;
            
        }
    }
    
}
