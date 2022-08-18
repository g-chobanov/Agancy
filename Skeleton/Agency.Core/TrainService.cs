using Agency.Core.Contracts;
using Agency.Models.Vehicles;
using Agency.Models.Vehicles.Contracts;
using Agency.Models.Contracts;
using Agency.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Core
{
    public class TrainService : ITrainService
    {
        private readonly IAgencyDatabase _db;

        public TrainService(IAgencyDatabase db)
        {
            _db = db;
        }

        public void AddTrain(ITrain train)
        {
            _db.Add(train);
        }

        public ITrain GetTrain(Guid ID)
        {
            return _db.Vehicles.FirstOrDefault(t => t.ClassType == VehicleClassType.Train && t.ID == ID) as ITrain;
        }

        public List<Train> GetTrains()
        {
            return _db.Vehicles.Where(t => t.ClassType == VehicleClassType.Train).Select(t => t as Train).ToList();
        }
    }
}
