using Agency.Models.DTOs;
using Agency.Models.Vehicles;
using Agency.Models.Vehicles.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Core.Contracts
{
    public interface IAirplaneService
    {
        Task<List<AirplaneDTO>> GetAirplanesAsync();

        Task CreateAirplaneAsync(AirplaneDTO airplaneDTO);

        Task<AirplaneDTO> GetAirplaneAsync(Guid ID);

        Task DeleteAirplaneAsync(Guid ID);

        Task UpdateAirplaneAsync(AirplaneDTO airplaneDTO);
    }
}
