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
        private readonly IJourneyService _journeyService;
        public JourneyController(IJourneyService journeyService)
        {
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
            return _journeyService.AddJourney(journey, vehicleID);
        }
    }
    
}
