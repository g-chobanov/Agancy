using System;

namespace Agency.Models.Contracts
{
    public interface ITicket
    {
        Guid ID { get; }
        decimal AdministrativeCosts { get; }

        IJourney Journey { get; }

        Guid JourneyID { get; }

        decimal CalculatePrice();
    }
}