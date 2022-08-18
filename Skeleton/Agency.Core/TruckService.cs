using Agency.Core.Contracts;
using Agency.Models.Enums;
using Agency.Models.Vehicles;
using Agency.Models.Vehicles.Contracts;
using Agency.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Core
{
    public class TruckService : ITruckService
    {
        private readonly IAgencyDatabase _db;
        public TruckService(IAgencyDatabase database)
        {
            _db = database;
        }

        public void AddTruck(ITruck Truck)
        {
            _db.Add(Truck);
        }

        public ITruck GetTruck(Guid ID)
        {
            return _db.Vehicles.FirstOrDefault(t => t.ClassType == VehicleClassType.Truck && t.ID == ID) as ITruck;
        }

        public List<Truck> GetTrucks()
        {
            return _db.Vehicles.Where(t => t.ClassType == VehicleClassType.Truck).Select(t => t as Truck).ToList();
        }
    }
}
