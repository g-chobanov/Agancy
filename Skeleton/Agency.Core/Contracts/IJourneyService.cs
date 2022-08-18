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

        void AddJourney(IJourney journey);

        IJourney GetJourney(Guid ID);
    }
}
