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
        public async Task<ActionResult<TrainDTO>> GetTrain(Guid index)
        {
            try
            {
                return Ok(await _service.GetTrainAsync(index));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //change it later
        [HttpGet("GetAllTrains")]
        public async Task<ActionResult<List<TrainDTO>>> GetAllTrains()
        {
            try
            {
                return Ok(await _service.GetTrainsAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("CreateTrain")]
        public async Task<ActionResult<TrainDTO>> CreateTrain([FromBody] TrainDTO train)
        {
            try
            {
                return Ok(await _service.CreateTrainAsync(train));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteTrain")]
        public async Task<ActionResult> DeleteTrain(Guid index)
        {
            try
            {
                await _service.DeleteTrainAsync(index);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPut("UpdateTrain")]
        public async Task<ActionResult<TrainDTO>> UpdateTrain([FromBody] TrainDTO train)
        {
            try
            {
                return Ok(await _service.UpdateTrainAsync(train));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
