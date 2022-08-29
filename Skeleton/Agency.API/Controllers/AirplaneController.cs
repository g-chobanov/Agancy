using Agency.Core.Contracts;
using Agency.Models.DTOs;
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
        public async Task<AirplaneDTO> GetAirplane(Guid index)
        {
            return await _service.GetAirplaneAsync(index);
        }
        //change it later
        [HttpGet("GetAllAirplanes")]
        public async Task<List<AirplaneDTO>> GetAllAirplanes()
        {
            return await _service.GetAirplanesAsync();
        }

        [HttpPost("CreateAirplane")]
        public async Task<AirplaneDTO> CreateAirplane([FromBody] AirplaneDTO airplane)
        {
            return await _service.CreateAirplaneAsync(airplane);
        }

        [HttpDelete("DeleteAirplane")]
        public async Task DeleteAirplane(Guid index)
        {
            await _service.DeleteAirplaneAsync(index);
        }

        [HttpPut("UpdateAirplane")]
        public async Task<AirplaneDTO> UpdateAirplane([FromBody] AirplaneDTO airplane)
        {
            return await _service.UpdateAirplaneAsync(airplane);
        }
    }
}
