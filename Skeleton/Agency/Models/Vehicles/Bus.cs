using Agency.Models.Vehicles.Contracts;
using Agency.Models.Vehicles.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Agency.Models.Enums;
using System.Text.Json.Serialization;
using Agency.Models.Models.Vehicles;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agency.Models.Vehicles
{

    [Table("Buses")]
    public class Bus : Vehicle, IBus
    {
        private const int _maxBusPassengers = 50;
        private const int _minBusPassengers = 10;

        [Key]
        [JsonIgnore]
        public override Guid ID { get; set; }

        [Range(_minBusPassengers, _maxBusPassengers, ErrorMessage = "A bus cannot have less than {1} passengers or more than {2} passengers.")]
        public override int PassengerCapacity { get; set; }

        [Range(((double)IVehicle._minPricePerKillometer), ((double)IVehicle._maxPricePerKillometer), ErrorMessage = "A vehicle with a price per kilometer lower than $0.10 or higher than $2.50 cannot exist!")]
        public override decimal PricePerKilometer { get; set; }

        [JsonIgnore]
        public override VehicleType Type { get; set; }

        [JsonIgnore]
        public override VehicleClassType ClassType => VehicleClassType.Bus;
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
