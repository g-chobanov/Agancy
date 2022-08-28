using Agency.Core.Contracts;
using Agency.Models.Vehicles.Contracts;
using Agency.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agency.Models.Vehicles.Enums;
using Agency.Models.Data;
using Agency.Models.Models.Vehicles;
using Agency.Models.DTOs;
using Agency.Models.DTOMappers;
using Microsoft.EntityFrameworkCore;

namespace Agency.Core
{
    public class VehicleService : IVehicleService
    {
        private readonly AgencyDatabaseContext _context;
        public VehicleService(AgencyDatabaseContext context)
        {
            _context = context; 
        }
        public async Task<VehicleDTO> GetVehicleAsync(Guid ID)
        {
            var vehicle = await _context.Vehicles.FirstOrDefaultAsync(t => t.ID == ID);
            if (vehicle == null)
            {
                throw new ArgumentNullException("vehicle does not exist");
            }
            return vehicle.ToDTO();
        }

        public async Task<List<VehicleDTO>> GetVehiclesByTypeAsync(VehicleType type)
        {
            return await _context.Vehicles.Where(t => t.Type == type).Select(t => t.ToDTO()).ToListAsync();
        }

        public async Task<List<VehicleDTO>> GetVehiclesAsync()
        {
            return await _context.Vehicles.Select(t => t.ToDTO()).ToListAsync();
        }
    }
}
