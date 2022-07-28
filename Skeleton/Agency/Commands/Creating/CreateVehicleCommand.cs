// https://i.imgflip.com/2ercfg.jpg
using System;
using System.Collections.Generic;
using Agency.Commands.Contracts;
using Agency.Core.Contracts;

namespace Agency.Commands.Creating
{
    public abstract class CreateVehicleCommand : ICommand
    {
        protected readonly IAgencyFactory factory;
        protected readonly IEngine engine;

        protected CreateVehicleCommand(IAgencyFactory factory, IEngine engine)
        {
            this.factory = factory;
            this.engine = engine;
        }
        public abstract string Execute(IList<string> parameters);
    }
}