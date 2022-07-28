using Agency.Commands.Creating;
using Agency.Constants;
using Agency.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traveller.Commands.Creating
{
    // TODO
    public class CreateAirplaneCommand : CreateVehicleCommand
    {
        public CreateAirplaneCommand(IAgencyFactory factory, IEngine engine) : base(factory, engine)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            int passangerCapacity;
            decimal pricePerKilometer;
            bool hasFreeFood;

            try
            {
                passangerCapacity = int.Parse(parameters[0]);
                pricePerKilometer = decimal.Parse(parameters[1], CultureInfoConstant.Culture);
                hasFreeFood = bool.Parse(parameters[2]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateAirplane command parameters.");
            }
            try
            {
                var airplane = this.factory.CreateAirplane(passangerCapacity, pricePerKilometer, hasFreeFood);
                this.engine.AgencyDatabase.Add(airplane);
            }
            catch (ArgumentException AE)
            {
                throw AE;
            }
            

            return $"Vehicle with ID {engine.AgencyDatabase.Vehicles.Count - 1} was created.";
        }
    }
}
