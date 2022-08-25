using Agency.Core.Contracts;
using Agency.Models.DTOs;
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
        public BusController (IBusService service)
        {
            _service = service;
        }

        [HttpGet("GetBus")]
        public async Task<BusDTO> GetBus(Guid index)
        {
            return await _service.GetBusAsync(index);
        }

        [HttpGet("GetAllBuses")]
        public async Task<List<BusDTO>> GetAllBuses()
        {
            return await _service.GetBusesAsync();
        }

        [HttpPost("CreateBus")]
        public async Task CreateBus([FromBody] BusDTO bus)
        {
            await _service.AddBusAsync(bus);
        }

        [HttpDelete("DeleteBus")]
        public async Task DeleteBus(Guid index)
        {
            await _service.DeleteBusAsync(index);
        }

        [HttpPut("UpdateBus")]
        public async Task UpdateBus([FromBody] BusDTO bus, Guid ID)
        {
            await _service.UpdateBusAsync(ID, bus);
        }
    }
}
