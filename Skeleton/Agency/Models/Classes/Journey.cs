using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;
using Agency.Models.Contracts;
using Agency.Models.Models.Vehicles;
using Agency.Models.Vehicles.Contracts;

namespace Agency.Models.Classes
{
    public class Journey : IJourney
    {
        private const int _maxStringLength = 25;
        private const int _minStringLength = 5;

        private const int _maxDistance = 5000;
        private const int _minDistance = 5;

        [Key]
        [JsonIgnore]
        public Guid ID { get; set; }

        [StringLength(_maxStringLength, MinimumLength = _minStringLength, ErrorMessage = "The Destination's length cannot be less than {2} or more than {1} symbols long.")]
        public string Destination { get; set;  }

        [Range(_minDistance, _maxDistance, ErrorMessage = "The Distance cannot be less than {1} or more than {2} kilometers.")]
        public int Distance { get; set;  }

        [StringLength(_maxStringLength, MinimumLength = _minStringLength, ErrorMessage = "The StartingLocation's length cannot be less than {2} or more than {1} symbols long.")]
        public string StartLocation { get; set; }

        
        public Guid VehicleId { get; set; }
        [ForeignKey("VehicleId")]
        [JsonIgnore]
        public Vehicle Vehicle { get; set; }

        public Journey()
        {
            ID = Guid.NewGuid();
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
