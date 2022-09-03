using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Models.DTOs
{
    public class CargoShipDTO
    {
        private const decimal _minPrice = 0.50m;
        private const decimal _maxPrice = 2.50m;

        private const int _minCap = 100;
        private const int _maxCap = 2000;

        private const int _minStorage = 15;
        private const int _maxStorage = 400;

        public Guid ID { get; set; }

        [Required(ErrorMessage = "Passenger capacity is missing!")]
        [Range(_minCap, _maxCap, ErrorMessage = "A ship cannot have less than {1} passengers or more than {2} passengers.")]
        public int PassengerCapacity { get; set; }

        [Required(ErrorMessage ="Price per kilometer is missing!")]
        [Range((double)_minPrice, (double)_maxPrice, ErrorMessage = "A ship with price per kilometer lower than {1} or higher than {2} cannot exist!")]
        public decimal PricePerKilometer { get; set; }

        [Required(ErrorMessage = "Storage is missing!")]
        [Range(_minStorage, _maxStorage, ErrorMessage = "Ship storage must be between {1} and {2}")]
        public int Storage { get; set; }
    }
}
