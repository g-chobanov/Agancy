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
    public interface ITrainService
    {
        Task<List<TrainDTO>> GetTrainsAsync();

        Task AddTrainAsync(TrainDTO airplaneDTO);

        Task<TrainDTO> GetTrainAsync(Guid ID);

        Task DeleteTrainAsync(Guid ID);

        Task UpdateTrainAsync(Guid ID, TrainDTO airplaneDTO);
    }
}
