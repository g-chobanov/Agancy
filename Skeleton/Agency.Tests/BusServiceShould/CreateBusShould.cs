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

namespace Agency.Tests.BusServiceTest
{
    [TestClass]
    public class CreateBusShould
    {
        [TestMethod]
        public async Task CreateAriplaneShould_AddNewBus()
        {
            //Arange
            var testContext = new AgencyDatabaseContext(AgencyTestUtils.GetOptions());
            var sut = new BusService(testContext);
            int testCap = 30;
            decimal testPPK = 1.7m;
            var testBus = new BusDTO
            {
                PassengerCapacity = testCap,
                PricePerKilometer = testPPK,
            };

            //Act 
            await sut.CreateBusAsync(testBus);
            var actualBus = testContext.Buses.FirstOrDefault(t => t.PassengerCapacity == testCap && t.PricePerKilometer == testPPK);

            //Assert
            Assert.IsNotNull(actualBus);
            Assert.AreEqual(VehicleType.Land, actualBus.Type);
        }

    }
}
