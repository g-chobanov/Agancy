using Agency.Constants;
using Agency.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agency.Commands.Creating
{
    public class CreateCargoShipCommand : CreateVehicleCommand
    {
        public CreateCargoShipCommand(IAgencyFactory factory, IEngine engine) : base(factory, engine)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            int passengerCapacity;
            decimal pricePerKilometer;
            double cargo;

            try
            {
                passengerCapacity = int.Parse(parameters[0]);
                pricePerKilometer = decimal.Parse(parameters[1], CultureInfoConstant.Culture);
                cargo = double.Parse(parameters[2], CultureInfoConstant.Culture);
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateCargoShip command parameters.");
            }

            try
            {
                var cargoShip = this.factory.CreateCargoShip(passengerCapacity, pricePerKilometer, cargo);
                this.engine.Vehicles.Add(cargoShip);
            }
            catch (ArgumentException AE)
            {
                throw AE;
            }


            return $"Vehicle with ID {engine.Vehicles.Count - 1} was created.";
        }
    }
}
