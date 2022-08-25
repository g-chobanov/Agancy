using System;
using System.Collections.Generic;

namespace DBTests.Data
{
    public partial class Ticket
    {
        public Guid Id { get; set; }
        public decimal AdministrativeCosts { get; set; }
        public Guid JourneyId { get; set; }

        public virtual Journey Journey { get; set; } = null!;
    }
}
