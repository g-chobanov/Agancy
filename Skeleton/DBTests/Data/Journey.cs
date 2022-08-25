using System;
using System.Collections.Generic;

namespace DBTests.Data
{
    public partial class Journey
    {
        public Journey()
        {
            Tickets = new HashSet<Ticket>();
        }

        public Guid Id { get; set; }
        public string? Destination { get; set; }
        public int Distance { get; set; }
        public string? StartLocation { get; set; }
        public Guid VehicleId { get; set; }

        public virtual Vehicle Vehicle { get; set; } = null!;
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
