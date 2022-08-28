using Agency.Core.Contracts;
using Agency.Models.Classes;
using Agency.Models.Contracts;
using Agency.Models.Data;
using Agency.Models.DTOMappers;
using Agency.Models.DTOs;
using Agency.Models.Models.Vehicles;
using Agency.Models.Vehicles;
using Agency.Models.Vehicles.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Core
{
    public class JourneyService : IJourneyService
    {
        private readonly AgencyDatabaseContext _context;
        public JourneyService(AgencyDatabaseContext context)
        {
            _context = context;
        }

        //validate here
        public async Task<bool> CreateJourneyAsync(JourneyDTO journeyDTO)
        {
            Vehicle vehicle = await _context.Vehicles.FirstOrDefaultAsync(t => t.ID == journeyDTO.VehicleID);
            if (vehicle == null)
            {
                return false;
            }
            var newJourney = new Journey();
            _ = newJourney.TakeFromDTO(journeyDTO);
            await _context.Journeys.AddAsync(newJourney);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<JourneyDTO> GetJourneyAsync(Guid ID)
        {
            var journey = await _context.Journeys.FirstOrDefaultAsync(t => t.ID == ID);
            if(journey == null)
            {
                throw new ArgumentNullException("Journey was not found!");
            }
            return journey.ToDTO();
        }

        public async Task<List<JourneyDTO>> GetJourneysAsync()
        {
            return await _context.Journeys.Select(t => t.ToDTO()).ToListAsync();
        }

        
        public async Task DeleteJourneyAsync(Guid ID)
        {
            var journey = await _context.Journeys.FirstOrDefaultAsync(t => t.ID == ID);
            if (journey == null)
            {
                throw new ArgumentNullException("Journey was not found!");
            }
            _context.Journeys.Remove(journey);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateJourneyAsync(JourneyDTO journeyDTO)
        {
            var journey = await _context.Journeys.FirstOrDefaultAsync(t => t.ID == journeyDTO.ID);
            if (journey == null)
            {
                throw new ArgumentNullException("Journey was not found!");
            }
            _ = journey.TakeFromDTO(journeyDTO);

            await _context.SaveChangesAsync();
        }

        public async Task<decimal> GetTravelCostsAsync(Guid ID)
        {
            var journey = await _context.Journeys
                .Include(t => t.Vehicle)
                .FirstOrDefaultAsync(t => t.ID == ID);
            if (journey == null)
            {
                throw new ArgumentNullException("Journey not found!");
            }
            return journey.CalculateTravelCosts();

        }
    }
}
