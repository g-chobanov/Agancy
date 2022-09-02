using Agency.Models.Contracts;
using Agency.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Core.Contracts
{
    public interface ITicketService
    {
        Task<List<TicketDTO>> GetTicketsAsync();

        Task<TicketDTO> CreateTicketAsync(TicketDTO ticket);

        Task<TicketDTO> GetTicketAsync(Guid ID);

        Task DeleteTicketAsync(Guid ID);

        Task<TicketDTO> UpdateTicketAsync(TicketDTO ticketDTO);

        Task<decimal> GetPriceAsync(Guid ID);
    }
}
