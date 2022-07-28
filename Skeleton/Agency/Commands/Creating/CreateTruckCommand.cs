using Agency.Constants;
using Agency.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agency.Commands.Creating
{
    internal class CreateTruckCommand : CreateVehicleCommand
    {
        public CreateTruckCommand(IAgencyFactory factory, IEngine engine) : base(factory, engine)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            int passengerCapacity;
            decimal pricePerKilometer;
            int storage;

            try
            {
                passengerCapacity = int.Parse(parameters[0]);
                pricePerKilometer = decimal.Parse(parameters[1], CultureInfoConstant.Culture);
                storage = int.Parse(parameters[2]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateTruck command parameters.");
            }

            try
            {
                var train = this.factory.CreateTruck(passengerCapacity, pricePerKilometer, storage);
                this.engine.AgencyDatabase.Add(train);
            }
            catch (ArgumentException AE)
            {
                throw AE;
            }


            return $"Vehicle with ID {engine.AgencyDatabase.Vehicles.Count - 1} was created.";
        }
    }
}
