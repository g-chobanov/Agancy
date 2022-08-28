using Agency.Models.DTOs;
using Agency.Models.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Models.DTOMappers
{
    public static class VehicleDTOMapper
    {
        public static VehicleDTO TakeFromVehicle(this VehicleDTO dto, Vehicle vehicle)
        {
            dto.ID = vehicle.ID;
            dto.StringVehicleInfo = vehicle.ToString();

            return dto;
        }

        public static VehicleDTO ToDTO(this Vehicle vehicle)
        {
            VehicleDTO dto = new VehicleDTO
            {
                ID = vehicle.ID,
                StringVehicleInfo = vehicle.ToString(),
            };

            return dto;
        }
    }
}
