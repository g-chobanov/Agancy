using Agency.Models.Classes;
using Agency.Models.Data;
using Agency.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Models.DTOMappers
{
    public static class JourneyMapper
    {
        public static JourneyDTO ToDTO(this Journey journey)
        {
            var dto = new JourneyDTO
            {
                ID = journey.ID,
                Destination = journey.Destination,
                StartLocation = journey.StartLocation,
                Distance = journey.Distance,
                VehicleID = journey.VehicleId,
            };
            return dto;
        }

        public static Journey TakeFromDTO(this Journey journey, JourneyDTO dto)
        {
            journey.ID = dto.ID;
            journey.Destination = dto.Destination;
            journey.StartLocation = dto.StartLocation;
            journey.Distance = dto.Distance;
            journey.VehicleId = dto.VehicleID;

            return journey;
        }
    }
}
