using System;
using System.Collections.Generic;
using System.Text;

namespace Agency.Models.Vehicles.Contracts
{
    public interface ICargoShip : IVehicle
    {
        double Cargo { get; set; }
    }
}
