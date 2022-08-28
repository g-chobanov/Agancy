using Agency.Models.Classes;
using System;

namespace Agency.Models.Contracts
{
    public interface ITicket
    {
        Guid ID { get; }
        decimal AdministrativeCosts { get; }
        Guid JourneyID { get; }
        Journey Journey { get; }
        decimal CalculatePrice();
    }
}