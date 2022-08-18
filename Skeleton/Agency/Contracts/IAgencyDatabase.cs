using Agency.Models.Vehicles.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agency.Models.Contracts
{
    public interface IAgencyDatabase
    {
        IList<IVehicle> Vehicles { get; }

        IList<IJourney> Journeys { get;  }

        IList<ITicket> Tickets { get; }

        void Add(IVehicle vehicle);

        void Add(IJourney journey);

        void Add(ITicket ticket);
    }
}
