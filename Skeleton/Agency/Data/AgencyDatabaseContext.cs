using System;
using System.Collections.Generic;
using Agency.Models.Classes;
using Agency.Models.Contracts;
using Agency.Models.Models.Vehicles;
using Agency.Models.Vehicles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Agency.Models.Data
{
    public partial class AgencyDatabaseContext : DbContext 
    {
        
        public AgencyDatabaseContext()
        {
        }

        public AgencyDatabaseContext(DbContextOptions<AgencyDatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Bus> Buses { get; set; }
        public DbSet<Airplane> Airplanes { get; set; }
        public DbSet<Truck> Trucks { get; set; }
        public DbSet<Train> Trains { get; set; }
        public DbSet<CargoShip> CargoShips { get; set; }
        public DbSet<Journey> Journeys { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-OHA5UQF\\SQLEXPRESS;Database=AgencyDatabase;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
