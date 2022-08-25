using System;
using System.Collections.Generic;

namespace DBTests.Data
{
    public partial class CargoShip
    {
        public Guid Id { get; set; }
        public int Storage { get; set; }

        public virtual Vehicle IdNavigation { get; set; } = null!;
    }
}
