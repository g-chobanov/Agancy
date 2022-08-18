using Agency.Models.Vehicles.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Core.Contracts
{
    public interface IVehicleService
    {
        List<IVehicle> GetVehicles();

        IVehicle GetVehicle(Guid id);
    }
}
