using Agency.Models.Vehicles;
using Agency.Models.Vehicles.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Core.Contracts
{
    public interface IAirplaneService
    {
        List<Airplane> GetAirplanes();

        void AddAirplane(IAirplane Airplane);

        IAirplane GetAirplane(Guid ID);
    }
}
