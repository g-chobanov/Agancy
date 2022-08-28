using Agency.Core.Contracts;
using Agency.Models.Contracts;
using Agency.Models.Data;
using Agency.Models.DTOs;
using Agency.Models.Enums;
using Agency.Models.Vehicles;
using Agency.Models.Vehicles.Contracts;
using Agency.Models.DTOMappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agency.Models.Vehicles.Enums;
using Microsoft.EntityFrameworkCore;

namespace Agency.Core
{
    public class  AirplaneService : IAirplaneService
    {
        private readonly AgencyDatabaseContext _context;
        public AirplaneService(AgencyDatabaseContext context)
        {
            _context = context;
        }

        public async Task CreateAirplaneAsync(AirplaneDTO airplaneDTO)
        {
            Airplane newAirplane = new Airplane();
            _ = newAirplane.TakeFromDTO(airplaneDTO);
            newAirplane.Type = VehicleType.Air;
            await _context.Airplanes.AddAsync(newAirplane);
            await _context.SaveChangesAsync();
        }

        public async Task<AirplaneDTO> GetAirplaneAsync(Guid ID)
        {
            var airplane = await _context.Airplanes.FirstOrDefaultAsync(t => t.ID == ID);
            if(airplane == null)
            {
                throw new ArgumentNullException("Airplane doesn't exist");
            }
            return airplane.ToDTO();
        }

        public async Task<List<AirplaneDTO>>  GetAirplanesAsync()
        {
            return await _context.Airplanes.Select(t => t.ToDTO()).ToListAsync();
        }

        public async Task DeleteAirplaneAsync(Guid ID)
        {
            var airplane = await _context.Airplanes.FirstOrDefaultAsync(t => t.ID == ID);
            if (airplane == null)
            {
                throw new ArgumentNullException("Airplane doesn't exist");
            }
            _context.Airplanes.Remove(airplane);

            await _context.SaveChangesAsync();

        }

        public async Task UpdateAirplaneAsync(AirplaneDTO airplaneDTO)
        {
            var airplane = await _context.Airplanes.FirstOrDefaultAsync(t => t.ID ==airplaneDTO.ID);
            if (airplane == null)
            {
                throw new ArgumentNullException("Airplane doesn't exist");
            }
            _ = airplane.TakeFromDTO(airplaneDTO);

            await _context.SaveChangesAsync();
        }
    }
}
