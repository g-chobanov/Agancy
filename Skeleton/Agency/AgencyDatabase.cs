using Agency.Models.Contracts;
using Agency.Models.Vehicles.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agency.Models
{
    public class AgencyDatabase : IAgencyDatabase
    {

        public IList<IVehicle> Vehicles { get; }

        public IList<IJourney> Journeys { get;  }

        public IList<ITicket> Tickets { get; }

        public AgencyDatabase() 
        {
            Vehicles = new List<IVehicle>();
            Journeys = new List<IJourney>();
            Tickets = new List<ITicket>();
        }

        public void Add(IVehicle vehicle)
        {
            Vehicles.Add(vehicle);
        }

        public void Add(IJourney journey)
        {
            Journeys.Add(journey);
        }

        public void Add(ITicket ticket)
        {
            Tickets.Add(ticket);
        }
    }
}
