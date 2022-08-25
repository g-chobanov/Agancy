using System;
using System.Collections.Generic;

namespace DBTests.Data
{
    public partial class bus
    {
        public Guid Id { get; set; }

        public virtual Vehicle IdNavigation { get; set; } = null!;
    }
}
