using Agency.Commands.Contracts;
using Agency.Constants;
using Agency.Core.Contracts;
using Agency.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traveller.Commands.Creating
{
    // TODO
    public class CreateTicketCommand : ICommand
    {
        private readonly IAgencyFactory _agencyFactory;
        private readonly IEngine _engine;

        public CreateTicketCommand(IAgencyFactory agencyFactory, IEngine engine)
        {
            _agencyFactory = agencyFactory;
            _engine = engine;
        }

        public string Execute(IList<string> parameters)
        {
            IJourney journey;
            decimal administrativeCosts;

            try
            {
                journey = this._engine.AgencyDatabase.Journeys[int.Parse(parameters[0])];
                administrativeCosts = decimal.Parse(parameters[1], CultureInfoConstant.Culture);
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateTicket command parameters.");
            }

            var ticket = this._agencyFactory.CreateTicket(journey, administrativeCosts);
            this._engine.AgencyDatabase.Add(ticket);

            return $"Ticket with ID {_engine.AgencyDatabase.Tickets.Count - 1} was created.";
        }
    }
}
