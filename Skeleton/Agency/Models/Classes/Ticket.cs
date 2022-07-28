using Agency.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agency.Models.Classes
{
    internal class Ticket : ITicket
    {
        public decimal AdministrativeCosts { get; set; }

        public IJourney Journey { get; set; }

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
