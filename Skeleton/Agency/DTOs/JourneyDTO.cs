using Agency.Models.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Models.DTOs
{
    public class JourneyDTO
    {
        public Guid ID { get; set; }
        public string Destination { get; set; }
        public int Distance { get; set; }
        public string StartLocation { get; set; }
        public Guid VehicleID { get; set; }
    }
}
