using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Models.DTOs
{
    public class TrainDTO
    {
        private const decimal _minPrice = 0.70m;
        private const decimal _maxPrice = 1.70m;

        private const int _minCap = 5;
        private const int _maxCap = 200;

        private const int _minCarts = 5;
        private const int _maxCarts = 15;
        public Guid ID { get; set; }

        
        [Required(ErrorMessage = "Passenger capacity is missing!")]
        [Range(_minCap, _maxCap, ErrorMessage = "A train with passenger capacity less than {1} and higher than {2} cannot exist1")]
        public int PassengerCapacity { get; set; }

        [Required(ErrorMessage = "Price per kilometer is missing!")]
        [Range((double)_minPrice, (double)_maxPrice, ErrorMessage = "A train with price per kilometer lower than {1} or higher than {2} cannot exist!")]
        public decimal PricePerKilometer { get; set; }

        [Range(_minCarts, _maxCarts, ErrorMessage = "Train carts must be between {1} and {2}")]
        public int Carts { get; set; }
    }
}
