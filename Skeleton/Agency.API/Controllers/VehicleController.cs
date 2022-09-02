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
        public async Task<ActionResult<VehicleDTO>> GetVehicle(Guid id)
        {
            try
            {
                return Ok(await _service.GetVehicleAsync(id));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAllVehicles")]
        public async Task<ActionResult<List<VehicleDTO>>> GetAllVehicles()
        {
            try
            {
                return Ok(await _service.GetVehiclesAsync());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteVehicle")]
        public async Task<ActionResult> DeleteVehicle(Guid id)
        {
            try
            {
                await _service.DeleteVehicleAsync(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
