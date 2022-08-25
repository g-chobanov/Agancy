using Agency.Core.Contracts;
using Agency.Models.Classes;
using Agency.Models.Contracts;
using Agency.Models.Models.Vehicles;
using Agency.Models.Vehicles.Contracts;
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
        private readonly IVehicleService _vehicleService;
        public JourneyService(IAgencyDatabase database, IVehicleService vehicleService)
        {
            _db = database;
            _vehicleService = vehicleService;
        }

        //validate here
        public bool AddJourney(Journey journey, Guid vehicleId)
        {
            Vehicle vehicle = _vehicleService.GetVehicle(vehicleId) as Vehicle;
            if (vehicle == null)
            {
                return false;
            }
            journey.Vehicle = vehicle;
            journey.VehicleId = vehicleId;
            _db.Add(journey);
            return true;
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
