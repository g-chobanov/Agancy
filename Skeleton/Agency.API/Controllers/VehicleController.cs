using Agency.Core.Contracts;
using Agency.Models.DTOs;
using Agency.Models.Models.Vehicles;
using Agency.Models.Vehicles.Contracts;
using Agency.Models.Vehicles.Enums;
using Microsoft.AspNetCore.Mvc;
namespace Agency.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehicleController : ControllerBase
    {
        //private string createCommand = "createbus";
        private readonly IVehicleService _service;
        public VehicleController(IVehicleService service)
        {
            _service = service;
        }

        [HttpGet("GetVehicle")]
        public async Task<VehicleDTO> GetVehicle(Guid id)
        {
            return await _service.GetVehicleAsync(id);
        }

        [HttpGet("GetAllVehicles")]
        public async Task<List<VehicleDTO>> GetAllVehicles()
        {
            return await _service.GetVehiclesAsync();
        }

        [HttpGet("GetVehiclesByType")]
        public async Task<List<VehicleDTO>> GetAllVehiclesByType(VehicleType type)
        {
            return await _service.GetVehiclesByTypeAsync(type);
        }

    }
}
