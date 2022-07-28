using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Agency.Models.Contracts;
using Agency.Models.Vehicles.Contracts;

namespace Agency.Models.Classes
{
    static class JourneyConstants
    {
        public const int MaxStringLength = 25;
        public const int MinStringLength = 5;

        public const int MaxDistance = 5000;
        public const int MinDistance = 5;
    }
    internal class Journey : IJourney
    {
        [StringLength(JourneyConstants.MaxStringLength, MinimumLength = JourneyConstants.MinStringLength, ErrorMessage = "The Destination's length cannot be less than 5 or more than 25 symbols long.")]
        public string Destination { get; }

        [Range(JourneyConstants.MinDistance, JourneyConstants.MaxDistance, ErrorMessage = "The Distance cannot be less than 5 or more than 5000 kilometers.")]
        public int Distance { get; }

        [StringLength(JourneyConstants.MaxStringLength, MinimumLength = JourneyConstants.MinStringLength, ErrorMessage = "The StartingLocation's length cannot be less than 5 or more than 25 symbols long.")]
        public string StartLocation { get; }

        public IVehicle Vehicle { get; }

        public Journey(string startLocation , string destination, int distance,  IVehicle vehicle)
        {
            StartLocation = startLocation;
            Destination = destination;
            Distance = distance;
            Vehicle = vehicle;

            try
            {
                ValidatorUtility.ValidateAnnotations(this);
            }
            catch (ArgumentException AE)
            {
                throw AE;
            }
        }

        public decimal CalculateTravelCosts()
        {
            return this.Distance * this.Vehicle.PricePerKilometer;
        }
        public override string ToString()
        {
            string format = "Journey ----" + Environment.NewLine +
                            $"Start location: {this.StartLocation}" + Environment.NewLine +
                            $"Destination: {this.Destination}" + Environment.NewLine +
                            $"Distance: {this.Distance}" + Environment.NewLine +
                            $"Vehicle type: {this.Vehicle.Type}" + Environment.NewLine +
                            $"Travel costs: {this.CalculateTravelCosts()}";

            return format.Replace(',', '.');
        }
    }
}
