using Agency.Models.Classes;
using Agency.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Core.Contracts
{
    public interface IJourneyService
    {
        List<IJourney> GetJourneys();

        bool AddJourney(Journey journey, Guid vehicleID);

        IJourney GetJourney(Guid ID);
    }
}
