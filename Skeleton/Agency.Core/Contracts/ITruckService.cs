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
    public interface ITruckService
    {
        Task<List<TruckDTO>> GetTrucksAsync();

        Task CreateTruckAsync(TruckDTO airplaneDTO);

        Task<TruckDTO> GetTruckAsync(Guid ID);

        Task DeleteTruckAsync(Guid ID);

        Task UpdateTruckAsync(TruckDTO airplaneDTO);
    }
}
