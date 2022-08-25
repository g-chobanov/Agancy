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
    public interface ICargoShipService
    {
        Task<List<CargoShipDTO>> GetCargoShipsAsync();

        Task AddCargoShipAsync(CargoShipDTO cargoShupDTO);

        Task<CargoShipDTO> GetCargoShipAsync(Guid ID);

        Task DeleteCargoShipAsync(Guid ID);

        Task UpdateCargoShipAsync(Guid ID, CargoShipDTO cargoShupDTO);
    }
}
