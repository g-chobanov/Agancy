using Agency.Models.DTOs;
using Agency.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Models.DTOMappers
{
    public static class BusMapper
    {
        public static BusDTO ToDTO(this Bus bus)
        {
            var busDTO = new BusDTO
            {
                ID = bus.ID,
                PassengerCapacity = bus.PassengerCapacity,
                PricePerKilometer = bus.PricePerKilometer,
            };
            return busDTO;
        }

        public static Bus TakeFromDTO(this Bus bus, BusDTO dto)
        {
            bus.PassengerCapacity = dto.PassengerCapacity;
            bus.PricePerKilometer = dto.PricePerKilometer;

            return bus;
        }
    }
}
