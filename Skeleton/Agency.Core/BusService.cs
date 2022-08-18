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
    public class BusService : IBusService
    {
        private readonly IAgencyDatabase _db;
        public BusService(IAgencyDatabase database)
        {
            _db = database;
        }

        public void AddBus(IBus bus)
        {
            _db.Add(bus);

        }

        public IBus GetBus(Guid ID)
        {
            return _db.Vehicles.FirstOrDefault(t => t.ClassType == VehicleClassType.Bus && t.ID == ID) as IBus;
        }

        public List<Bus> GetBuses()
        {
            return _db.Vehicles.Where(t => t.ClassType == VehicleClassType.Bus).Select(t => t as Bus).ToList();
        }
    }
}
