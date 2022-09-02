using Agency.Core.Contracts;
using Agency.Models.Classes;
using Agency.Models.Contracts;
using Agency.Models.DTOs;
using Agency.Models.Vehicles.Contracts;
using Microsoft.AspNetCore.Mvc;
namespace Agency.API.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _service;  
        public TicketController(ITicketService service)
        {
            _service = service;
        }

        [HttpGet("GetTicket")]
        public async Task<ActionResult<TicketDTO>> GetTicket(Guid id)
        {
            try
            {
                return Ok(await _service.GetTicketAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAllTickets")]
        public async Task<ActionResult<List<TicketDTO>>> GetAllTickets()
        {
            try
            {
                return Ok(await _service.GetTicketsAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("CreateTicket")]
        public async Task<ActionResult<TicketDTO>> CreateTicket([FromBody] TicketDTO ticket)
        {
            try
            {
                return Ok(await _service.CreateTicketAsync(ticket));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("DeleteTicket")]
        public async Task<ActionResult> DeleteTicket(Guid index)
        {
            try
            {
                await _service.DeleteTicketAsync(index);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("UpdateTicket")]
        public async Task<ActionResult<TicketDTO>> UpdateTicket([FromBody] TicketDTO ticket)
        {
            try
            {
                return Ok(await _service.UpdateTicketAsync(ticket));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetPrice")]
        public async Task<ActionResult<decimal>> GetPrice(Guid id)
        {
            try
            {
                return Ok(await _service.GetPriceAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
    
}
