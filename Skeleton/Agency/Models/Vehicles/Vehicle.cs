using Agency.Models.Enums;
using Agency.Models.Vehicles.Contracts;
using Agency.Models.Vehicles.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Models.Models.Vehicles
{
    [Table("Vehicles")]
    public abstract class Vehicle : IVehicle
    {
        public abstract Guid ID { get; set; }

        public abstract int PassengerCapacity { get; set; }

        public abstract decimal PricePerKilometer { get; set; }

        public abstract VehicleType Type { get; set; }

        public abstract VehicleClassType ClassType { get;}
    }
}
