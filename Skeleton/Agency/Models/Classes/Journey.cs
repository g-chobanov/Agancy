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

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid ID { get; set; }
        public string Destination { get; set;  }
        public int Distance { get; set;  }
        public string StartLocation { get; set; }
        public Guid VehicleId { get; set; }

        [ForeignKey("VehicleId")]
        public Vehicle Vehicle { get; set; }

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
