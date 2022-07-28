using System;
using System.Collections.Generic;
using System.Text;
using Agency.Models.Vehicles.Contracts;
using Agency.Models.Vehicles.Enums;
using System.ComponentModel.DataAnnotations;

namespace Agency.Models.Vehicles.VehicleClasses
{
    internal class Airplane : IAirplane
    {
        [Range(LawsConstants.MinPassengers, LawsConstants.MaxPassengers, ErrorMessage = "A vehicle with less than {1} passengers or more than {2} passengers cannot exist!")]
        public int PassangerCapacity { get; }

        [Range(((double)LawsConstants.MinPricePerKillometer), ((double)LawsConstants.MaxPricePerKillometer), ErrorMessage = "A vehicle with a price per kilometer lower than $0.10 or higher than $2.50 cannot exist!")]
        public decimal PricePerKilometer { get; }
        
        public bool HasFreeFood { get; }

        public VehicleType Type { get; } = VehicleType.Air;

        public Airplane(int passangerCapacity, decimal pricePerKilometer, bool hasFreeFood) 
        {
            this.PassangerCapacity = passangerCapacity;
            this.PricePerKilometer = pricePerKilometer;
            this.HasFreeFood = hasFreeFood;

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

            string format = "Airplane ----" + Environment.NewLine +
                            $"Passenger capacity: {this.PassangerCapacity}" + Environment.NewLine +
                            $"Price per kilometer: {this.PricePerKilometer}" + Environment.NewLine +
                            $"Vehicle type: {this.Type}" + Environment.NewLine +
                            $"Has free food: {this.HasFreeFood}";
            

            return format.Replace(',', '.');
        }
    }
}
