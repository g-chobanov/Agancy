using Agency.Core.Contracts;
using Agency.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Core
{
    public class JourneyService : IJourneyService
    {
        private readonly IAgencyDatabase _db;
        public JourneyService(IAgencyDatabase database)
        {
            _db = database;
        }

        //validate here
        public void AddJourney(IJourney Journey)
        {
            _db.Add(Journey);
        }

        public IJourney GetJourney(Guid ID)
        {
            return _db.Journeys.ToList().Find(j => j.ID == ID);
        }

        public List<IJourney> GetJourneys()
        {
            return _db.Journeys.ToList();
        }
    }
}
