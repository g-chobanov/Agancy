using Agency.Core.Contracts;
using Agency.Models.Vehicles;
using Agency.Models.Vehicles.Contracts;
using Agency.Models.Contracts;
using Agency.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agency.Models.DTOMappers;
using Agency.Models.Data;
using Agency.Models.DTOs;
using Agency.Models.Vehicles.Enums;
using Microsoft.EntityFrameworkCore;

namespace Agency.Core
{
    public class TrainService : ITrainService
    {
        private readonly AgencyDatabaseContext _context;
        public TrainService(AgencyDatabaseContext context)
        {
            _context = context;
        }

        public async Task<TrainDTO> CreateTrainAsync(TrainDTO trainDTO)
        {
            Train newTrain = new Train();
            _ = newTrain.TakeFromDTO(trainDTO);
            newTrain.Type = VehicleType.Land;
            await _context.Trains.AddAsync(newTrain);

            await _context.SaveChangesAsync();

            return newTrain.ToDTO();
        }

        public async Task<TrainDTO> GetTrainAsync(Guid ID)
        {
            var train = await _context.Trains.FirstOrDefaultAsync(t => t.ID == ID);
            if (train == null)
            {
                throw new ArgumentNullException("Train doesn't exist");
            }
            return train.ToDTO();
        }

        public async Task<List<TrainDTO>> GetTrainsAsync()
        {
            return await _context.Trains.Select(t => t.ToDTO()).ToListAsync();
        }

        public async Task DeleteTrainAsync(Guid ID)
        {
            var train = await _context.Trains.FirstOrDefaultAsync(t => t.ID == ID);
            if (train == null)
            {
                throw new ArgumentNullException("Train doesn't exist");
            }
            _context.Trains.Remove(train);

            await _context.SaveChangesAsync();

        }

        public async Task<TrainDTO> UpdateTrainAsync(TrainDTO trainDTO)
        {
            var train = await _context.Trains.FirstOrDefaultAsync(t => t.ID == trainDTO.ID);
            if (train == null)
            {
                throw new ArgumentNullException("Train doesn't exist");
            }
            _ = train.TakeFromDTO(trainDTO);

            await _context.SaveChangesAsync();

            return trainDTO;
        }
    }
}
