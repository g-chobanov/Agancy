using Agency.Models.DTOs;
using Agency.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Models.DTOMappers
{
    public static class CargoShipMapper
    {
        public static CargoShipDTO ToDTO(this CargoShip cargoShip)
        {
            var cargoShipDTO = new CargoShipDTO
            {
                ID = cargoShip.ID,
                PassengerCapacity = cargoShip.PassengerCapacity,
                PricePerKilometer = cargoShip.PricePerKilometer,
                Storage = cargoShip.Storage
            };
            return cargoShipDTO;
        }

        public static CargoShip TakeFromDTO(this CargoShip cargoShip, CargoShipDTO dto)
        {
            cargoShip.PassengerCapacity = dto.PassengerCapacity;
            cargoShip.PricePerKilometer = dto.PricePerKilometer;
            cargoShip.Storage = dto.Storage;
            
            return cargoShip;
        }
    }
}
