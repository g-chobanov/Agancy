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
    [Table("Trains")]
    public class Train : Vehicle, ITrain
    {
        private const int _maxTrainPassengers = 150;
        private const int _minTrainPassengers = 30;

        private const int _maxCarts = 15;
        private const int _minCarts = 1;

        [Key]
        [JsonIgnore]
        public override Guid ID { get; set; }

        [Range(_minTrainPassengers, _maxTrainPassengers, ErrorMessage = "A train cannot have less than {1} passengers or more than {2} passengers.")]
        public override int PassengerCapacity { get; set; }

        [Range(((double)IVehicle._minPricePerKillometer), ((double)IVehicle._maxPricePerKillometer), ErrorMessage = "A vehicle with a price per kilometer lower than $0.10 or higher than $2.50 cannot exist!")]
        public override decimal PricePerKilometer { get; set; }

        [Range(_minCarts, _maxCarts, ErrorMessage = "A train cannot have less than 1 cart or more than 15 carts.")]
        public int Carts { get; set; }

        [JsonIgnore]
        public override VehicleType Type { get; set; }

        [JsonIgnore]
        public override VehicleClassType ClassType => VehicleClassType.Train;
        public Train()
        {
            ID = Guid.NewGuid();
        }


        public override string ToString()
        {
            string format = "Train ----" + Environment.NewLine +
                            $"Passenger capacity: {PassengerCapacity}" + Environment.NewLine +
                            $"Price per kilometer: {PricePerKilometer}" + Environment.NewLine +
                            $"Vehicle type: {Type}" + Environment.NewLine +
                            $"Carts amount: {Carts}";

            return format.Replace(',', '.');
        }

    }
}
