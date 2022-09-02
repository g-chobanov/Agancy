using Agency.Core.Contracts;
using Agency.Models.Classes;
using Agency.Models.Contracts;
using Agency.Models.Data;
using Agency.Models.DTOMappers;
using Agency.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Core
{
    public class TicketService : ITicketService
    {
        private readonly AgencyDatabaseContext _context;
        public TicketService(AgencyDatabaseContext context)
        {
            _context = context;
        }

        public async Task<TicketDTO> CreateTicketAsync(TicketDTO ticketDTO)
        {
            Journey journey = await _context.Journeys.FirstOrDefaultAsync(t => t.ID == ticketDTO.JourneyID);
            if (journey == null)
            {
                throw new ArgumentNullException("Journey was not found!");
            }
            var newTicket = new Ticket();
            _ = newTicket.TakeFromDTO(ticketDTO);
            newTicket.ID = Guid.NewGuid();
            await _context.Tickets.AddAsync(newTicket);

            await _context.SaveChangesAsync();

            return newTicket.ToDTO();
        }

        public async Task<TicketDTO> GetTicketAsync(Guid ID)
        {
            var ticket = await _context.Tickets.FirstOrDefaultAsync(t => t.ID == ID);
            if (ticket == null)
            {
                throw new ArgumentNullException("Ticket was not found!");
            }
            return ticket.ToDTO();
        }

        public async Task<List<TicketDTO>> GetTicketsAsync()
        {
            return await _context.Tickets.Select(t => t.ToDTO()).ToListAsync();
        }


        public async Task DeleteTicketAsync(Guid ID)
        {
            var ticket = await _context.Tickets.FirstOrDefaultAsync(t => t.ID == ID);
            if (ticket == null)
            {
                throw new ArgumentNullException("Ticket was not found!");
            }
            _context.Tickets.Remove(ticket);

            await _context.SaveChangesAsync();
        }

        public async Task<TicketDTO> UpdateTicketAsync(TicketDTO ticketDTO)
        {
            var ticket = await _context.Tickets.FirstOrDefaultAsync(t => t.ID == ticketDTO.ID);
            if (ticket == null)
            {
                throw new ArgumentNullException("Ticket was not found!");
            }
            if (await _context.Journeys.FirstOrDefaultAsync(t => t.ID == ticketDTO.JourneyID) == null)
            {
                throw new ArgumentNullException("You can't create a ticket with a non-existing Journey");
            }
            _ = ticket.TakeFromDTO(ticketDTO);

            await _context.SaveChangesAsync();

            return ticketDTO;
        }

        public async Task<decimal> GetPriceAsync(Guid ID)
        {
            var ticket = await _context.Tickets
                .Include(t => t.Journey)
                .ThenInclude(j => j.Vehicle)
                .FirstOrDefaultAsync(t => t.ID == ID);
            if (ticket == null)
            {
                throw new ArgumentNullException("Ticket not found!");
            }
            return ticket.CalculatePrice();

        }
    }
}
