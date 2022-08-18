﻿using Agency.Models.Vehicles.Contracts;
using System;

namespace Agency.Models.Contracts
{
    public interface IJourney
    {
        Guid ID { get;}
        string Destination { get; }

        int Distance { get; }

        string StartLocation { get;}

        IVehicle Vehicle { get; }

        decimal CalculateTravelCosts();
    }
}