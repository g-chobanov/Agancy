using Agency.Core.Contracts;
using Agency.Models.Vehicles.Contracts;
using Agency.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Core
{
    public class VehicleService : IVehicleService
    {
        private readonly IAgencyDatabase _db;
        public VehicleService(IAgencyDatabase database)
        {
            _db = database;
        }
        public IVehicle GetVehicle(Guid ID)
        {
            return _db.Vehicles.ToList().Find(t => t.ID == ID);
        }

        public List<IVehicle> GetVehicles()
        {
            return _db.Vehicles.ToList();
        }
    }
}
