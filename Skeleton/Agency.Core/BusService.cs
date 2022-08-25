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
using Agency.Models.DTOs;
using Agency.Models.Data;
using Agency.Models.DTOMappers;
using Agency.Models.Vehicles.Enums;
using Microsoft.EntityFrameworkCore;

namespace Agency.Core
{
    public class BusService : IBusService
    {
        private readonly AgencyDatabaseContext _context;
        public BusService(AgencyDatabaseContext context)
        {
            _context = context;
        }

        public async Task AddBusAsync(BusDTO busDTO)
        {
            Bus newBus = new Bus();
            _ = newBus.TakeFromDTO(busDTO);
            newBus.Type = VehicleType.Land;
            await _context.Buses.AddAsync(newBus);

            await _context.SaveChangesAsync();
        }

        public async Task<BusDTO> GetBusAsync(Guid ID)
        {
            var bus = await _context.Buses.FirstOrDefaultAsync(t => t.ID == ID);
            if (bus == null)
            {
                throw new ArgumentNullException("Bus doesn't exist");
            }
            return bus.ToDTO();
        }

        public async Task<List<BusDTO>> GetBusesAsync()
        {
            return await _context.Buses.Select(t => t.ToDTO()).ToListAsync();
        }

        public async Task DeleteBusAsync(Guid ID)
        {
            var bus = await _context.Buses.FirstOrDefaultAsync(t => t.ID == ID);
            if (bus == null)
            {
                throw new ArgumentNullException("Bus doesn't exist");
            }
            _context.Buses.Remove(bus);

            await _context.SaveChangesAsync();

        }

        public async Task UpdateBusAsync(Guid ID, BusDTO busDTO)
        {
            var bus = await _context.Buses.FirstOrDefaultAsync(t => t.ID == ID);
            if (bus == null)
            {
                throw new ArgumentNullException("Bus doesn't exist");
            }
            _ = bus.TakeFromDTO(busDTO);

            await _context.SaveChangesAsync();
        }
    }
}
