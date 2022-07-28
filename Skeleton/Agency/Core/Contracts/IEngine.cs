using System.Collections.Generic;
using Agency.Models.Contracts;
using Agency.Models.Vehicles.Contracts;

namespace Agency.Core.Contracts
{
    public interface IEngine
    {
        void Start();

        IReader Reader { get; set; }

        IWriter Writer { get; set; }

        IParser Parser { get; set; }

        IAgencyDatabase AgencyDatabase { get; set; }
    }
}
