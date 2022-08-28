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
        public async Task<TicketDTO> GetTicket(Guid id)
        {
            return await _service.GetTicketAsync(id);
        }

        [HttpGet("GetAllTickets")]
        public async Task<List<TicketDTO>> GetAllTickets()
        {
            return await _service.GetTicketsAsync();
        }
        [HttpPost("CreateTicket")]
        public async Task<bool> CreateTicket([FromBody] TicketDTO ticket)
        {
            return await _service.CreateTicketAsync(ticket);
        }
        [HttpDelete("DeleteTicket")]
        public async Task DeleteTicket(Guid index)
        {
            await _service.DeleteTicketAsync(index);
        }
        [HttpPut("UpdateTicket")]
        public async Task UpdateTicket([FromBody] TicketDTO ticket)
        {
            await _service.UpdateTicketAsync(ticket);
        }
        [HttpPost("GetTravelCosts")]
        public async Task<decimal> testing(Guid ID)
        {
            return await _service.GetPriceAsync(ID);
        }
    }
    
}
