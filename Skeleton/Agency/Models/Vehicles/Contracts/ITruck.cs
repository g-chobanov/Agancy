using System;
using System.Collections.Generic;
using System.Text;

namespace Agency.Models.Vehicles.Contracts
{
    public interface ITruck : IVehicle
    {
        int Storage { get; set; }
    }
}
