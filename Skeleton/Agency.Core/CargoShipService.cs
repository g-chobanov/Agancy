using Agency.Core.Contracts;
using Agency.Models.Contracts;
using Agency.Models.Data;
using Agency.Models.DTOMappers;
using Agency.Models.DTOs;
using Agency.Models.Enums;
using Agency.Models.Vehicles;
using Agency.Models.Vehicles.Contracts;
using Agency.Models.Vehicles.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Agency.Core
{
    public class CargoShipService : ICargoShipService
    {
        private readonly AgencyDatabaseContext _context;
        public CargoShipService(AgencyDatabaseContext context)
        {
            _context = context;
        }

        public async Task AddCargoShipAsync(CargoShipDTO cargoShipDTO)
        {
            CargoShip newCargoShip = new CargoShip();
            _ = newCargoShip.TakeFromDTO(cargoShipDTO);
            newCargoShip.Type = VehicleType.Sea;
            await _context.CargoShips.AddAsync(newCargoShip);

            await _context.SaveChangesAsync();
        }

        public async Task<CargoShipDTO> GetCargoShipAsync(Guid ID)
        {
            var cargoShip = await _context.CargoShips.FirstOrDefaultAsync(t => t.ID == ID);
            if (cargoShip == null)
            {
                throw new ArgumentNullException("CargoShip doesn't exist");
            }
            return cargoShip.ToDTO();
        }

        public async Task<List<CargoShipDTO>> GetCargoShipsAsync()
        {
            return await _context.CargoShips.Select(t => t.ToDTO()).ToListAsync();
        }

        public async Task DeleteCargoShipAsync(Guid ID)
        {
            var cargoShip = await _context.CargoShips.FirstOrDefaultAsync(t => t.ID == ID);
            if (cargoShip == null)
            {
                throw new ArgumentNullException("CargoShip doesn't exist");
            }
            _context.CargoShips.Remove(cargoShip);

            await _context.SaveChangesAsync();

        }

        public async Task UpdateCargoShipAsync(Guid ID, CargoShipDTO cargoShipDTO)
        {
            var cargoShip = await _context.CargoShips.FirstOrDefaultAsync(t => t.ID == ID);
            if (cargoShip == null)
            {
                throw new ArgumentNullException("CargoShip doesn't exist");
            }
            _ = cargoShip.TakeFromDTO(cargoShipDTO);

            await _context.SaveChangesAsync();
        }
    }

}
