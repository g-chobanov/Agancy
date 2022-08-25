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
    [Table("Trucks")]
    public class Truck : Vehicle, ITruck
    {
        [Key]
        [JsonIgnore]
        public override Guid ID { get; set; }

        [Range(IVehicle._minPassengers, IVehicle._maxPassengers, ErrorMessage = "A vehicle with less than {1} passengers or more than {2} passengers cannot exist!")]
        public override int PassengerCapacity { get; set; }

        [Range(((double)IVehicle._minPricePerKillometer), ((double)IVehicle._maxPricePerKillometer), ErrorMessage = "A vehicle with a price per kilometer lower than $0.10 or higher than $2.50 cannot exist!")]
        public override decimal PricePerKilometer { get; set; }

        [JsonIgnore]
        public override VehicleType Type { get; set; }

        [JsonIgnore]
        public override VehicleClassType ClassType => VehicleClassType.Truck;

        public int Storage { get; set; }

        public Truck()
        {
            ID = Guid.NewGuid();
        }

        public override string ToString()
        {
            string format = "Truck ----" + Environment.NewLine +
                            $"Passenger capacity: {PassengerCapacity}" + Environment.NewLine +
                            $"Price per kilometer: {PricePerKilometer}" + Environment.NewLine +
                            $"Vehicle type: {Type}" + Environment.NewLine +
                            $"Storage: {Storage}";

            return format.Replace(',', '.');
        }
    }
}
