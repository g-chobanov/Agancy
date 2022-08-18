using Agency.Core.Contracts;
using Agency.Models.Contracts;
using Agency.Models.Enums;
using Agency.Models.Vehicles;
using Agency.Models.Vehicles.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Core
{
    public class AirplaneService : IAirplaneService
    {
        private readonly IAgencyDatabase _db;
        public AirplaneService(IAgencyDatabase database)
        {
            _db = database;
        }

        public void AddAirplane(IAirplane Airplane)
        {
            _db.Add(Airplane);

        }

        //add && to where or FirstOrDefault
        public IAirplane GetAirplane(Guid ID)
        {
            return _db.Vehicles.FirstOrDefault(t => t.ClassType == VehicleClassType.Airplane && t.ID == ID) as IAirplane;
        }

        //IAirplane
        public List<Airplane> GetAirplanes()
        {
            return _db.Vehicles.Where(t => t.ClassType == VehicleClassType.Airplane).Select(t => t as Airplane).ToList();
        }
    }
}
