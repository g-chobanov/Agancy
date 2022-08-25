using Agency.Models.DTOs;
using Agency.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Models.DTOMappers
{
    public static class TruckMapper
    {
        public static TruckDTO ToDTO(this Truck truck)
        {
            var truckDTO = new TruckDTO
            {
                ID = truck.ID,
                PassengerCapacity = truck.PassengerCapacity,
                PricePerKilometer = truck.PricePerKilometer,
                Storage = truck.Storage
            };
            return truckDTO;
        }

        public static Truck TakeFromDTO(this Truck truck, TruckDTO dto)
        {
            truck.PassengerCapacity = dto.PassengerCapacity;
            truck.PricePerKilometer = dto.PricePerKilometer;
            truck.Storage = dto.Storage;

            return truck;
        }
    }
}
