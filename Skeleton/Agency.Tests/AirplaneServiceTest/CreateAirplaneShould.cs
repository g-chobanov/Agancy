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

namespace Agency.Tests.AirplaneServiceTest
{
    [TestClass]
    public class CreateTrainShould
    {
        [TestMethod]
        public async Task CreateAriplaneShould_AddNewAirplane()
        {
            //Arange
            var testContext = new AgencyDatabaseContext(AgencyTestUtils.GetOptions());
            var sut = new AirplaneService(testContext);
            int testCap = 30;
            decimal testPPK = 1.7m;
            var testAirplane = new AirplaneDTO
            {
                PassengerCapacity = testCap,
                PricePerKilometer = testPPK,
                HasFreeFood = true
            };

            //Act 
            await sut.AddAirplaneAsync(testAirplane);
            var acutalAirplane = testContext.Airplanes.FirstOrDefault(t => t.PassengerCapacity == testCap && t.PricePerKilometer == testPPK && t.HasFreeFood);

            //Assert
            Assert.IsNotNull(acutalAirplane);
            Assert.AreEqual(VehicleType.Air, acutalAirplane.Type);
        }

    }
}
