using Agency.Models.Classes;
using Agency.Models.Data;
using Agency.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Models.DTOMappers
{
    public static class TicketMapper
    {
        public static TicketDTO ToDTO(this Ticket ticket)
        {
            var dto = new TicketDTO
            {
                ID = ticket.ID,
                AdministrativeCosts = ticket.AdministrativeCosts,
                JourneyID = ticket.JourneyID,
                
            };
            return dto;
        }

        public static Ticket TakeFromDTO(this Ticket ticket, TicketDTO dto)
        {
            ticket.ID = dto.ID;
            ticket.AdministrativeCosts = dto.AdministrativeCosts;
            ticket.JourneyID = dto.JourneyID;

            return ticket;
        }
    }
}
