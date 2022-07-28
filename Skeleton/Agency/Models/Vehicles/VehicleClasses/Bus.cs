using Agency.Models.Vehicles.Contracts;
using Agency.Models.Vehicles.Enums;
using Agency.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Agency.Models.Vehicles.VehicleClasses
{
    static class BusConstants
    {
        public const int MaxBusPassengers = 50;
        public const int MinBusPassengers = 10;

    }
    internal class Bus : IBus
    {

        [Range(BusConstants.MinBusPassengers, BusConstants.MaxBusPassengers, ErrorMessage = "A bus cannot have less than 10 passengers or more than 50 passengers.")]
        public int PassangerCapacity { get; }

        [Range(((double)LawsConstants.MinPricePerKillometer), ((double)LawsConstants.MaxPricePerKillometer), ErrorMessage = "A vehicle with a price per kilometer lower than $0.10 or higher than $2.50 cannot exist!")]
        public decimal PricePerKilometer { get; }

        public VehicleType Type { get; } = VehicleType.Land;

        public Bus(int passangerCapacity, decimal pricePerKilometer)
        {
            this.PassangerCapacity = passangerCapacity;
            this.PricePerKilometer = pricePerKilometer;

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
            string format = "Bus ----" + Environment.NewLine +
                            $"Passenger capacity: {this.PassangerCapacity}" + Environment.NewLine +
                            $"Price per kilometer: {this.PricePerKilometer}" + Environment.NewLine +
                            $"Vehicle type: {this.Type}";

            return format.Replace(',','.');
        }
    }
}
