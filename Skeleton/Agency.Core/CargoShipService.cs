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
    public class CargoShipService : ICargoShipService
    {
        private readonly IAgencyDatabase _db;
        public CargoShipService(IAgencyDatabase database)
        {
            _db = database;
        }

        public void AddCargoShip(ICargoShip CargoShip)
        {
            _db.Add(CargoShip);
        }

        public ICargoShip GetCargoShip(Guid ID)
        {
            return _db.Vehicles.FirstOrDefault(t => t.ClassType == VehicleClassType.CargoShip && t.ID == ID) as ICargoShip;
        }

        public List<CargoShip> GetCargoShips()
        {
            return _db.Vehicles.Where(t => t.ClassType == VehicleClassType.CargoShip).Select(t => t as CargoShip).ToList();
        }
    }
}
