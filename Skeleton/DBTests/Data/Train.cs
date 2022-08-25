using System;
using System.Collections.Generic;

namespace DBTests.Data
{
    public partial class Train
    {
        public Guid Id { get; set; }
        public int Carts { get; set; }

        public virtual Vehicle IdNavigation { get; set; } = null!;
    }
}
