using Agency.Models.Classes;
using Agency.Models.Contracts;
using Agency.Models.DTOs;
using Agency.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Core.Contracts
{
    public interface IJourneyService
    {
        Task<List<JourneyDTO>> GetJourneysAsync();

        Task<JourneyDTO> CreateJourneyAsync(JourneyDTO journey);

        Task<JourneyDTO> GetJourneyAsync(Guid ID);

        Task<string> GetJourneyStringInfoAsync(Guid ID);

        Task DeleteJourneyAsync(Guid ID);

        Task<JourneyDTO> UpdateJourneyAsync(JourneyDTO journeyDTO);

        Task<decimal> GetTravelCostsAsync(Guid ID);
    }
}
