using Agency.Models.Vehicles.Contracts;
using Agency.Models.Vehicles.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Agency.Models.Enums;
using System.Text.Json.Serialization;

namespace Agency.Models.Vehicles
{

    public class Bus :  IBus
    {
        private const int _maxBusPassengers = 50;
        private const int _minBusPassengers = 10;

        [JsonIgnore]
        public Guid ID { get; }

        [Range(_minBusPassengers, _maxBusPassengers, ErrorMessage = "A bus cannot have less than {1} passengers or more than {2} passengers.")]
        public int PassengerCapacity { get; set; }

        [Range(((double)IVehicle._minPricePerKillometer), ((double)IVehicle._maxPricePerKillometer), ErrorMessage = "A vehicle with a price per kilometer lower than $0.10 or higher than $2.50 cannot exist!")]
        public decimal PricePerKilometer { get; set; }

        [JsonIgnore]
        public VehicleType Type => VehicleType.Land;

        [JsonIgnore]
        public VehicleClassType ClassType => VehicleClassType.Bus;
        public Bus()
        {
            ID = Guid.NewGuid();
        }

        public override string ToString()
        {
            string format = "Bus ----" + Environment.NewLine +
                            $"Passenger capacity: {PassengerCapacity}" + Environment.NewLine +
                            $"Price per kilometer: {PricePerKilometer}" + Environment.NewLine +
                            $"Vehicle type: {Type}";

            return format.Replace(',', '.');
        }
    }
}
