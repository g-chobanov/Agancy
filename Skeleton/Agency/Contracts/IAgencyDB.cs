using Agency.Models.Classes;
using Agency.Models.Vehicles;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Models.Contracts
{
    public interface IAgencyDB
    {
        public DbSet<Bus> Buses { get; set; }
        public DbSet<Airplane> Airplanes { get; set; }
        public DbSet<Truck> Trucks { get; set; }
        public DbSet<Train> Trains { get; set; }
        public DbSet<CargoShip> CargoShips { get; set; }
        public DbSet<Journey> Journeys { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
    }
}
