using Agency.Models.DTOs;
using Agency.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Models.DTOMappers
{
    public static class AirplaneMapper
    {
        public static AirplaneDTO ToDTO(this Airplane airplane)
        {
            var airplaneDTO = new AirplaneDTO
            {
                ID = airplane.ID,
                PassengerCapacity = airplane.PassengerCapacity,
                PricePerKilometer = airplane.PricePerKilometer,
                HasFreeFood = airplane.HasFreeFood,
            };
            return airplaneDTO;
        }

        public static Airplane TakeFromDTO(this Airplane airplane, AirplaneDTO dto)
        {
            airplane.PassengerCapacity = dto.PassengerCapacity;
            airplane.PricePerKilometer = dto.PricePerKilometer;
            airplane.HasFreeFood = dto.HasFreeFood;

            return airplane;
        }
    }
}
