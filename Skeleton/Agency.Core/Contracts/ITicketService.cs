using Agency.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Core.Contracts
{
    public interface ITicketService
    {
        List<ITicket> GetTickets();

        void AddTicket(ITicket ticket);

        ITicket GetTicket(Guid ID);
    }
}
