using Agency.Core.Contracts;
using Agency.Models.Enums;
using Agency.Models.Vehicles;
using Agency.Models.Vehicles.Contracts;
using Agency.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agency.Models.Data;
using Agency.Models.DTOs;
using Agency.Models.DTOMappers;
using Agency.Models.Vehicles.Enums;
using Microsoft.EntityFrameworkCore;

namespace Agency.Core
{
    public class TruckService : ITruckService
    {
        private readonly AgencyDatabaseContext _context;
        public TruckService(AgencyDatabaseContext context)
        {
            _context = context;
        }

        public async Task AddTruckAsync(TruckDTO truckDTO)
        {
            Truck newTruck = new Truck();
            _ = newTruck.TakeFromDTO(truckDTO);
            newTruck.Type = VehicleType.Land;
            await _context.Trucks.AddAsync(newTruck);

            await _context.SaveChangesAsync();
        }

        public async Task<TruckDTO> GetTruckAsync(Guid ID)
        {
            var truck = await _context.Trucks.FirstOrDefaultAsync(t => t.ID == ID);
            if (truck == null)
            {
                throw new ArgumentNullException("Truck doesn't exist");
            }
            return truck.ToDTO();
        }

        public async Task<List<TruckDTO>> GetTrucksAsync()
        {
            return await _context.Trucks.Select(t => t.ToDTO()).ToListAsync();
        }

        public async Task DeleteTruckAsync(Guid ID)
        {
            var truck = await _context.Trucks.FirstOrDefaultAsync(t => t.ID == ID);
            if (truck == null)
            {
                throw new ArgumentNullException("Truck doesn't exist");
            }
            _context.Trucks.Remove(truck);

            await _context.SaveChangesAsync();

        }

        public async Task UpdateTruckAsync(Guid ID, TruckDTO truckDTO)
        {
            var truck = await _context.Trucks.FirstOrDefaultAsync(t => t.ID == ID);
            if (truck == null)
            {
                throw new ArgumentNullException("Truck doesn't exist");
            }
            _ = truck.TakeFromDTO(truckDTO);

            await _context.SaveChangesAsync();
        }
    }
}
