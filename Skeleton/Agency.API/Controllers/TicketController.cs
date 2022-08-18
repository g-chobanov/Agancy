using Agency.Core.Contracts;
using Agency.Models.Classes;
using Agency.Models.Contracts;
using Agency.Models.Vehicles.Contracts;
using Microsoft.AspNetCore.Mvc;
namespace Agency.API.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly IJourneyService _journeyService;  
        private readonly ITicketService _ticketService;
        public TicketController(ITicketService ticketSerivce, IJourneyService jounreyService)
        {
            _ticketService = ticketSerivce;
            _journeyService = jounreyService;
        }

        [HttpGet("GetTicket")]
        public ITicket GetTicket(Guid id)
        {
            return _ticketService.GetTicket(id);
        }

        [HttpGet("GetAllTickets")]
        public List<ITicket> GetAllTickets()
        {
            return _ticketService.GetTickets();
        }
        [HttpPost("CreateTicket")]
        public bool CreateTicket([FromBody] Ticket Ticket, Guid journeyID)
        {
            IJourney journey = _journeyService.GetJourney(journeyID);
            if (journey == null)
            {
                return false;
            }
            Ticket.Journey = journey;
            _ticketService.AddTicket(Ticket);
            return true;

        }
    }
    
}
