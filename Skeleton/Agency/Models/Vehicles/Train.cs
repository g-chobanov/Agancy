using Agency.Models.Vehicles.Contracts;
using Agency.Models.Vehicles.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Agency.Models.Vehicles
{
    public class Train : ITrain
    {
        private const int _maxTrainPassengers = 150;
        private const int _minTrainPassengers = 30;

        private const int _maxCarts = 15;
        private const int _minCarts = 1;

        [Range(_minTrainPassengers, _maxTrainPassengers, ErrorMessage = "A train cannot have less than {1} passengers or more than {2} passengers.")]
        public int PassengerCapacity { get; set; }

        [Range(((double)IVehicle._minPricePerKillometer), ((double)IVehicle._maxPricePerKillometer), ErrorMessage = "A vehicle with a price per kilometer lower than $0.10 or higher than $2.50 cannot exist!")]
        public decimal PricePerKilometer { get; set; }

        [Range(_minCarts, _maxCarts, ErrorMessage = "A train cannot have less than 1 cart or more than 15 carts.")]
        public int Carts { get; set; }

        public VehicleType Type => VehicleType.Land;

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
