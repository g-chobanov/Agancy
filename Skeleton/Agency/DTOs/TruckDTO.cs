using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Models.DTOs
{
    public class TruckDTO
    {
        private const decimal _minPrice = 0.30m;
        private const decimal _maxPrice = 2.60m;

        private const int _minCap = 5;
        private const int _maxCap = 25;

        private const int _minStorage = 10;
        private const int _maxStorage = 100;
        public Guid ID { get; set; }

        [Required(ErrorMessage = "Passenger capacity is missing!")]
        [Range(_minCap, _maxCap, ErrorMessage = "A truck with passenger capacity less than {1} and higher than {2} cannot exist1")]
        public int PassengerCapacity { get; set; }


        [Required(ErrorMessage = "Price per kilometer is missing!")]
        [Range((double)_minPrice, (double)_maxPrice, ErrorMessage = "A truck with price per kilometer lower than {1} or higher than {2} cannot exist!")]
        public decimal PricePerKilometer { get; set; }

        [Range(_minStorage, _maxStorage, ErrorMessage = "Truck storage must be between {1} and {2}")]
        public int Storage { get; set; }
    }
}
