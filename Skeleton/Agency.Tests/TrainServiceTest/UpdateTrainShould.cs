using Agency.Core;
using Agency.Models.DTOMappers;
using Agency.Models.DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Tests.TrainServiceTest
{
    [TestClass]
    public class UpdateTrainShould
    {
        [TestMethod]
        public async Task UpdateTrainShould_ChangeTrainContents()
        {
            //Arange
            var testContext = AgencyTestUtils.GenerateContext();
            var sut = new TrainService(testContext);
            var testTrain = testContext.Trains.First();
            var testTrainDTO = testTrain.ToDTO();
            testTrainDTO.PassengerCapacity =-  1;
            
            //Act
            await sut.UpdateTrainAsync(testTrain.ID, testTrainDTO);

            //Assert 
            Assert.AreEqual(testTrain.PassengerCapacity, testTrainDTO.PassengerCapacity);

        }
    }
}
