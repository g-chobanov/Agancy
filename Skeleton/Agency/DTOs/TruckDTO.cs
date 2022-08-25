using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Models.DTOs
{
    public class TruckDTO
    {
        public Guid ID { get; set; }
        public int PassengerCapacity { get; set; }
        public decimal PricePerKilometer { get; set; }
        public int Storage { get; set; }
    }
}
