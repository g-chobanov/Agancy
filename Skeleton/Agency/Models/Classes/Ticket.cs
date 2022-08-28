using Agency.Models.Classes;
using Agency.Models.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Models.Classes
{
    public class Ticket : ITicket
    {
        [Key]
        public Guid ID { get; set; }
        public decimal AdministrativeCosts { get; set; }
        public Guid JourneyID { get; set; }
        [ForeignKey("JourneyID")]
        public Journey Journey { get; set; }
        public decimal CalculatePrice()
        {
            return this.AdministrativeCosts * Journey.CalculateTravelCosts();
        }
        public override string ToString()
        {
            string format = "Ticket ----" + Environment.NewLine +
                            $"Destination: {this.Journey.Destination}" + Environment.NewLine +
                            $"Travel Costs: {this.Journey.CalculateTravelCosts()}";

            return format.Replace(',', '.');
        }
    }
}
