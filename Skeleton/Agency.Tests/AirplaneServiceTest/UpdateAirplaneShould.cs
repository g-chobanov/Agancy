using Agency.Core;
using Agency.Models.DTOMappers;
using Agency.Models.DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Tests.AirplaneServiceTest
{
    [TestClass]
    public class UpdateAirplaneShould
    {
        [TestMethod]
        public async Task UpdateAirplaneShould_ChangeAirplaneContents()
        {
            //Arange
            var testContext = AgencyTestUtils.GenerateContext();
            var sut = new AirplaneService(testContext);
            var testAirplane = testContext.Airplanes.First();
            var testAirplaneDTO = testAirplane.ToDTO();
            testAirplaneDTO.PassengerCapacity =-  1;
            
            //Act
            await sut.UpdateAirplaneAsync(testAirplane.ID, testAirplaneDTO);

            //Assert 
            Assert.AreEqual(testAirplane.PassengerCapacity, testAirplaneDTO.PassengerCapacity);

        }
    }
}
