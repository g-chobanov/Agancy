using Agency.Models.Data;
using Agency.Models.Vehicles;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Tests
{
    public static class AgencyTestUtils
    {
        public static Guid airplaneID = Guid.NewGuid();
        public static Guid busID = Guid.NewGuid();
        public static Guid cargoShipID = Guid.NewGuid();
        public static Guid truckID = Guid.NewGuid();
        public static Guid trainID = Guid.NewGuid();
        public static DbContextOptions<AgencyDatabaseContext> GetOptions()
        {
            return new DbContextOptionsBuilder<AgencyDatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
        }

        public static void Seed(AgencyDatabaseContext context)
        {
            var airplanes = new[]
            {
                new Airplane
                {
                    ID = airplaneID,
                    PassengerCapacity = 50,
                    PricePerKilometer = 2.0m,
                    HasFreeFood = true,
                }
            };
            var buses = new[]
            {
                new Bus
                {
                    ID = busID,
                    PassengerCapacity = 60,
                    PricePerKilometer = 2.1m,
                },
            };
            var cargoShips = new[]
            {
                new CargoShip
                {
                    ID = cargoShipID,
                    PassengerCapacity = 40,
                    PricePerKilometer = 1.9m,
                    Storage = 20,
                },
            };
            var trains = new[]
            {
                new Train
                {
                    ID = trainID,
                    PassengerCapacity = 45,
                    PricePerKilometer = 1.8m,
                    Carts = 4,
                },
            };
            var trucks = new[]
            {
                new Truck
                {
                    ID = truckID,
                    PassengerCapacity = 55,
                    PricePerKilometer = 2.2m,
                    Storage = 19,
                },
            };

            context.AddRange(airplanes);
            context.AddRange(buses);
            context.AddRange(cargoShips);
            context.AddRange(trucks);
            context.AddRange(trains);

            context.SaveChanges();
        }

        public static AgencyDatabaseContext GenerateContext()
        {
            var dbContext = new AgencyDatabaseContext(GetOptions());
            Seed(dbContext);
            return dbContext;
        }
        
    }
}
