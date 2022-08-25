using Agency.Models.Models.Vehicles;
using Agency.Models.Vehicles.Contracts;
using System;

namespace Agency.Models.Contracts
{
    public interface IJourney
    {
        Guid ID { get;}
        string Destination { get; }

        int Distance { get; }

        string StartLocation { get;}

        Vehicle Vehicle { get; }

        Guid VehicleId { get; }

        decimal CalculateTravelCosts();
    }
}