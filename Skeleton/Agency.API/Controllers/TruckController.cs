using Agency.Core.Contracts;
using Agency.Models.DTOs;
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
        public async Task<TruckDTO> GetTruck(Guid index)
        {
            return await _service.GetTruckAsync(index);
        }
        [HttpGet("GetAllTrucks")]
        public async Task<List<TruckDTO>> GetAllTrucks()
        {
            return await _service.GetTrucksAsync();
        }

        [HttpPost("CreateTruck")]
        public async Task CreateTruck([FromBody] TruckDTO truck)
        {
            await _service.CreateTruckAsync(truck);
        }

        [HttpDelete("DeleteTruck")]
        public async Task DeleteTruck(Guid index)
        {
            await _service.DeleteTruckAsync(index);
        }

        [HttpPut("UpdateTruck")]
        public async Task UpdateTruck([FromBody] TruckDTO truck)
        {
            await _service.UpdateTruckAsync(truck);
        }


    }
}
