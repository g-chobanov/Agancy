using System;
using System.Collections.Generic;
using Agency.Commands.Contracts;
using Agency.Core.Contracts;
using Agency.Models.Vehicles.Contracts;

namespace Agency.Commands.Creating
{
    public class CreateJourneyCommand : ICommand
    {
        private readonly IAgencyFactory factory;
        private readonly IEngine engine;

        public CreateJourneyCommand(IAgencyFactory factory, IEngine engine)
        {
            this.factory = factory;
            this.engine = engine;
        }

        public string Execute(IList<string> parameters)
        {
            string startLocation;
            string destination;
            int distance;
            IVehicle vehicle;

            try
            {
                startLocation = parameters[0];
                destination = parameters[1];
                distance = int.Parse(parameters[2]);
                vehicle = this.engine.AgencyDatabase.Vehicles[int.Parse(parameters[3])];
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateJourney command parameters.");
            }

            try
            {
                var journey = this.factory.CreateJourney(startLocation, destination, distance, vehicle);
                this.engine.AgencyDatabase.Add(journey);
            }
            catch (ArgumentException AE)
            {
                throw AE;
            }
            

            return $"Journey with ID {engine.AgencyDatabase.Journeys.Count - 1} was created.";
        }

    }
}
