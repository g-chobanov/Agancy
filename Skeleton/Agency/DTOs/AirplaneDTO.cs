using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Models.DTOs
{
    public class AirplaneDTO
    {
        private const decimal _minPrice = 0.10m;
        private const decimal _maxPrice = 3.00m;
        
        private const int _minCap = 20;
        private const int _maxCap = 800;
        public Guid ID { get; set; }

        [Required(ErrorMessage = "Passenger capacity is missing!")]
        [Range(_minCap, _maxCap,ErrorMessage = "A plane with passenger capacity less than {1} and higher than {2} cannot exist1")]
        public int PassengerCapacity { get; set; }

        [Required(ErrorMessage ="Price per kilometer is missing!")]
        [Range((double)_minPrice, (double)_maxPrice, ErrorMessage = "A plane with a price per kilometer lower than {1} or higher than {2} cannot exist!")]
        public decimal PricePerKilometer { get; set; }

        [Required(ErrorMessage = "Has free food is not specified!")]
        public bool HasFreeFood { get; set;  }
    }
}
