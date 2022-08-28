﻿using Agency.Models.DTOs;
using Agency.Models.Vehicles;
using Agency.Models.Vehicles.Contracts;

namespace Agency.Core.Contracts
{
    public interface IBusService
    {
        Task<List<BusDTO>> GetBusesAsync();

        Task CreateBusAsync(BusDTO busDTO);

        Task<BusDTO> GetBusAsync(Guid ID);

        Task DeleteBusAsync(Guid ID);

        Task UpdateBusAsync(BusDTO busDTO);
    }
}