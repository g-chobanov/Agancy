using System;
using System.Collections.Generic;

namespace DBTests.Data
{
    public partial class Vehicle
    {
        public Vehicle()
        {
            Journeys = new HashSet<Journey>();
        }

        public Guid Id { get; set; }
        public int PassengerCapacity { get; set; }
        public decimal PricePerKilometer { get; set; }
        public int Type { get; set; }

        public virtual Airplane Airplane { get; set; } = null!;
        public virtual CargoShip CargoShip { get; set; } = null!;
        public virtual Train Train { get; set; } = null!;
        public virtual Truck Truck { get; set; } = null!;
        public virtual bus bus { get; set; } = null!;
        public virtual ICollection<Journey> Journeys { get; set; }
    }
}
