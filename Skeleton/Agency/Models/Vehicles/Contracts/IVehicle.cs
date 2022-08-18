using Agency.Models.Enums;
using Agency.Models.Vehicles.Enums;
using System;
using System.Text.Json.Serialization;

namespace Agency.Models.Vehicles.Contracts
{
    public interface IVehicle
    {
        protected const int _maxPassengers = 800;
        protected const int _minPassengers = 1;

        protected const decimal _maxPricePerKillometer = 2.50m;
        protected const decimal _minPricePerKillometer = 0.10m;

        
        Guid ID { get; }
        int PassengerCapacity { get; }

        decimal PricePerKilometer { get; }

        VehicleType Type { get; }

        VehicleClassType ClassType { get; }


    }
}