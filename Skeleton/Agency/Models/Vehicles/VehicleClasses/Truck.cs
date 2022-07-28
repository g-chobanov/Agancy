using Agency.Models.Vehicles.Contracts;
using Agency.Models.Vehicles.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agency.Models.Vehicles.VehicleClasses
{
    public class Truck : IVehicle
    {
        public int PassangerCapacity { get; set; }

        public decimal PricePerKilometer { get; set; }

        public VehicleType Type => VehicleType.Land;
    }
}
