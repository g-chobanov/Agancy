using Agency.Models.Vehicles.Contracts;
using Agency.Models.Vehicles.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Agency.Models.Vehicles.VehicleClasses
{
    public class Train : ITrain
    {
        private const int _maxTrainPassengers = 150;
        private const int _minTrainPassengers = 30;

        private const int _maxCarts = 15;
        private const int _minCarts = 1;

        [Range(_minTrainPassengers, _maxTrainPassengers, ErrorMessage = "A train cannot have less than 30 passengers or more than 150 passengers.")]
        public int PassangerCapacity { get; }

        [Range(((double)LawsConstants.MinPricePerKillometer), ((double)LawsConstants.MaxPricePerKillometer), ErrorMessage = "A vehicle with a price per kilometer lower than $0.10 or higher than $2.50 cannot exist!")]
        public decimal PricePerKilometer { get; }

        [Range(_minCarts, _maxCarts, ErrorMessage = "A train cannot have less than {1} cart or more than {2} carts.")]
        public int Carts { get; }

        public VehicleType Type { get; } = VehicleType.Land;

        public Train(int passangerCapacity, decimal pricePerKilometer, int carts) 
        {
            this.PassangerCapacity = passangerCapacity;
            this.PricePerKilometer = pricePerKilometer;
            this.Carts = carts;

            try
            {
                ValidatorUtility.ValidateAnnotations(this);
            }
            catch (ArgumentException AE)
            {
                throw AE;
            }
        }

        public override string ToString()
        {
            string format = "Train ----" + Environment.NewLine +
                            $"Passenger capacity: {this.PassangerCapacity}" + Environment.NewLine +
                            $"Price per kilometer: {this.PricePerKilometer}" + Environment.NewLine +
                            $"Vehicle type: {this.Type}" + Environment.NewLine +
                            $"Carts amount: {this.Carts}";

            return format.Replace(',', '.');
        }

    }
}
