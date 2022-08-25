using Agency.Models.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Agency.Models.Classes
{
    public class Ticket : ITicket
    {
        [Key]
        [JsonIgnore]
        public Guid ID { get; set; }
        public decimal AdministrativeCosts { get; set; }

        [ForeignKey("Journey")]
        public Guid JourneyID { get; set; }
        public IJourney Journey { get; set; }

        public Ticket()
        {
            ID = Guid.NewGuid();
        }
        public decimal CalculatePrice()
        {
            return this.AdministrativeCosts + this.Journey.CalculateTravelCosts();
        }
        public override string ToString()
        {
            string format = "Ticket ----" + Environment.NewLine +
                            $"Destination: {this.Journey.Destination}" + Environment.NewLine +
                            $"Price: {this.CalculatePrice()}";

            return format.Replace(',', '.');
        }
    }
}
