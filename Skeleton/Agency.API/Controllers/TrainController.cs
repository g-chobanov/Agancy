using Agency.Core.Contracts;
using Agency.Models.DTOs;
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
        public async Task<TrainDTO> GetTrain(Guid index)
        {
            return await _service.GetTrainAsync(index);
        }
        //change it later
        [HttpGet("GetAllTrains")]
        public async Task<List<TrainDTO>> GetAllTrains()
        {
            return await _service.GetTrainsAsync();
        }

        [HttpPost("CreateTrain")]
        public async Task CreateTrain([FromBody] TrainDTO train)
        {
            await _service.CreateTrainAsync(train);
        }

        [HttpDelete("DeleteTrain")]
        public async Task DeleteTrain(Guid index)
        {
            await _service.DeleteTrainAsync(index);
        }

        [HttpPut("UpdateTrain")]
        public async Task UpdateTrain([FromBody] TrainDTO train)
        {
            await _service.UpdateTrainAsync(train);
        }

    }
}
