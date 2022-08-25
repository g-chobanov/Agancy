using Agency.Models.DTOs;
using Agency.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Models.DTOMappers
{
    public static class TrainMapper
    {
        public static TrainDTO ToDTO(this Train train)
        {
            var trainDTO = new TrainDTO
            {
                ID = train.ID,
                PassengerCapacity = train.PassengerCapacity,
                PricePerKilometer = train.PricePerKilometer,
                Carts = train.Carts
            };
            return trainDTO;
        }

        public static Train TakeFromDTO(this Train train, TrainDTO dto)
        {
            train.PassengerCapacity = dto.PassengerCapacity;
            train.PricePerKilometer = dto.PricePerKilometer;
            train.Carts = dto.Carts;

            return train;
        }
    }
}
