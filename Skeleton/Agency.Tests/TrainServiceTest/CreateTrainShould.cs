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

namespace Agency.Tests.TrainServiceTest
{
    [TestClass]
    public class CreateTrainShould
    {
        [TestMethod]
        public async Task CreateAriplaneShould_AddNewTrain()
        {
            //Arange
            var testContext = new AgencyDatabaseContext(AgencyTestUtils.GetOptions());
            var sut = new TrainService(testContext);
            int testCap = 30;
            decimal testPPK = 1.7m;
            int testCarts = 5;
            var testTrain = new TrainDTO
            {
                PassengerCapacity = testCap,
                PricePerKilometer = testPPK,
                Carts = testCarts,
            };

            //Act 
            await sut.CreateTrainAsync(testTrain);
            var actualTrain = testContext.Trains.FirstOrDefault(t => t.PassengerCapacity == testCap && t.PricePerKilometer == testPPK && t.Carts == testCarts);

            //Assert
            Assert.IsNotNull(actualTrain);
            Assert.AreEqual(VehicleType.Land, actualTrain.Type);
        }

    }
}
