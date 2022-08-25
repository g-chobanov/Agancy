using System;
using System.Collections.Generic;

namespace DBTests.Data
{
    public partial class Airplane
    {
        public Guid Id { get; set; }
        public bool HasFreeFood { get; set; }

        public virtual Vehicle IdNavigation { get; set; } = null!;
    }
}
