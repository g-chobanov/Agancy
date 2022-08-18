using Agency.Core.Contracts;
using Agency.Models.Vehicles;
using Agency.Models.Vehicles.Contracts;
using Microsoft.AspNetCore.Mvc;
namespace Agency.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrainController : ControllerBase
    {
        private readonly ITrainService _service;
        public TrainController(ITrainService serivce)
        {
            _service = serivce;
        }

        [HttpGet("GetTrain")]
        public ITrain GetTrain(Guid index)
        {
            return _service.GetTrain(index);
            //return _database.Vehicles.Select(t => t.ID == tindex) as Train;
        }

        [HttpGet("GetAllTrains")]
        public List<Train> GetAllTrains()
        {
            return _service.GetTrains();
        }

        [HttpPost("CreateTrainJSON")]
        public bool CreateTrainJSON([FromBody]Train train)
        {
            if(train.ClassType != Models.Enums.VehicleClassType.Train)
            {
                return false;
            }
            if(train.Type != Models.Vehicles.Enums.VehicleType.Land)
            {
                return false;
            }
            _service.AddTrain(train);
            return true;
        }
        
    }
}
