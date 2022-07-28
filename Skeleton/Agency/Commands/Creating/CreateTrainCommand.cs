using System;
using System.Collections.Generic;
using System.Globalization;
using Agency.Commands.Contracts;
using Agency.Constants;
using Agency.Core.Contracts;

namespace Agency.Commands.Creating
{
    public class CreateTrainCommand : CreateVehicleCommand
    {

        public CreateTrainCommand(IAgencyFactory factory, IEngine engine) : base(factory, engine) 
        {
        }

        public override string Execute(IList<string> parameters)
        {
            int passengerCapacity;
            decimal pricePerKilometer;
            int cartsCount;

            try
            {
                passengerCapacity = int.Parse(parameters[0]);
                pricePerKilometer = decimal.Parse(parameters[1], CultureInfoConstant.Culture);
                cartsCount = int.Parse(parameters[2]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateTrain command parameters.");
            }

            try
            {
                var train = this.factory.CreateTrain(passengerCapacity, pricePerKilometer, cartsCount);
                this.engine.Vehicles.Add(train);
            }
            catch (ArgumentException AE)
            {
                throw AE;
            }
            

            return $"Vehicle with ID {engine.Vehicles.Count - 1} was created.";
        }
    }
}
