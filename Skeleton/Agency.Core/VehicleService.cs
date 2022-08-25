using Agency.Core.Contracts;
using Agency.Models.Vehicles.Contracts;
using Agency.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agency.Models.Vehicles.Enums;
using Agency.Models.Data;
using Agency.Models.Models.Vehicles;

namespace Agency.Core
{
    public class VehicleService : IVehicleService
    {
        private readonly IAgencyDatabase _db;
        private readonly AgencyDatabaseContext _context;
        public VehicleService(IAgencyDatabase database, AgencyDatabaseContext context)
        {
            _db = database;
            _context = context; 
        }
        public IVehicle GetVehicle(Guid ID)
        {
            return _db.Vehicles.ToList().Find(t => t.ID == ID);
        }

        public List<Vehicle> GetVehiclesByType(VehicleType type)
        {
            return _context.Vehicles.Where(t => t.Type == type).ToList();
        }

        public List<IVehicle> GetVehicles()
        {
            return _db.Vehicles.ToList();
        }
    }
}
