using Agency.Models.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Models.DTOs
{
    public class JourneyDTO
    {
        private const int _maxStringLength = 25;
        private const int _minStringLength = 5;

        private const int _maxDistance = 5000;
        private const int _minDistance = 5;
        public Guid ID { get; set; }

        [StringLength(_maxStringLength, MinimumLength = _minStringLength, ErrorMessage = "The Destination's length cannot be less than {2} or more than {1} symbols long.")]
        public string Destination { get; set; }

        [Range(_minDistance, _maxDistance, ErrorMessage = "The Distance cannot be less than {1} or more than {2} kilometers.")]
        public int Distance { get; set; }

        [StringLength(_maxStringLength, MinimumLength = _minStringLength, ErrorMessage = "The Starting Location's length cannot be less than {2} or more than {1} symbols long.")]
        public string StartLocation { get; set; }
        public Guid VehicleID { get; set; }
    }
}
