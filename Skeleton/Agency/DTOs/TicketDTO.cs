using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Models.DTOs
{
    public class TicketDTO
    {
        public Guid ID { get; set; }
        public decimal AdministrativeCosts { get; set; }
        public Guid JourneyID { get; set; }
    }
}
