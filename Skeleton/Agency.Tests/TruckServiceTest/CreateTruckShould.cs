using Agency.Core;
using Agency.Models;
using Agency.Models.Data;
using Agency.Models.DTOMappers;
using Agency.Models.DTOs;
using Agency.Models.Vehicles;
using Agency.Models.Vehicles.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Tests.TruckServiceTest
{
    [TestClass]
    public class CreateTruckShould
    {
        [TestMethod]
        public async Task CreateAriplaneShould_AddNewTruck()
        {
            //Arange
            var testContext = new AgencyDatabaseContext(AgencyTestUtils.GetOptions());
            var sut = new TruckService(testContext);
            int testCap = 30;
            decimal testPPK = 1.7m;
            int testStorage = 10;
            var testTruck = new TruckDTO
            {
                PassengerCapacity = testCap,
                PricePerKilometer = testPPK,
                Storage = testStorage,
            };

            //Act 
            await sut.AddTruckAsync(testTruck);
            var acutalTruck = testContext.Trucks.FirstOrDefault(t => t.PassengerCapacity == testCap && t.PricePerKilometer == testPPK && t.Storage == testStorage);

            //Assert
            Assert.IsNotNull(acutalTruck);
            Assert.AreEqual(VehicleType.Land, acutalTruck.Type);
        }

    }
}
