using System;
using System.Collections.Generic;
using System.Globalization;
using Agency.Commands.Contracts;
using Agency.Core.Contracts;
using Agency.Constants;

namespace Agency.Commands.Creating
{
    public class CreateBusCommand : CreateVehicleCommand
    { 
        public CreateBusCommand(IAgencyFactory factory, IEngine engine) : base(factory, engine)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            int passengerCapacity;
            decimal pricePerKilometer;

            try
            {
                passengerCapacity = int.Parse(parameters[0]);
                pricePerKilometer = decimal.Parse(parameters[1], CultureInfoConstant.Culture);
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateBus command parameters.");
            }

            try
            {
                var bus = this.factory.CreateBus(passengerCapacity, pricePerKilometer);
                this.engine.Vehicles.Add(bus);
            }
            catch (ArgumentException AE)
            {
                throw AE;
            }

            return $"Vehicle with ID {engine.Vehicles.Count - 1} was created.";
        }

    }
}
