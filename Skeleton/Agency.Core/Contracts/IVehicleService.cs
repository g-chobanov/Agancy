using Agency.Models.DTOs;
using Agency.Models.Models.Vehicles;
using Agency.Models.Vehicles.Contracts;
using Agency.Models.Vehicles.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Core.Contracts
{
    public interface IVehicleService
    {
        Task<List<VehicleDTO>> GetVehiclesAsync();

        Task<VehicleDTO> GetVehicleAsync(Guid id);

        Task<List<VehicleDTO>> GetVehiclesByTypeAsync(VehicleType type);

       
    }
}
