using Agency.Core.Contracts;
using Agency.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Core
{
    public class TicketService : ITicketService
    {
        private readonly IAgencyDatabase _db;
        public TicketService(IAgencyDatabase database)
        {
            _db = database;
        }

        public void AddTicket(ITicket Ticket)
        {
            _db.Add(Ticket);
        }

        public ITicket GetTicket(Guid ID)
        {
            return _db.Tickets.ToList().Find(t => t.ID == ID);
        }

        public List<ITicket> GetTickets()
        {
            return _db.Tickets.ToList();
        }
    }
}
