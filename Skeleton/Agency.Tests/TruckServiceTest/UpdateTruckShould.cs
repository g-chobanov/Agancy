using Agency.Core;
using Agency.Models.DTOMappers;
using Agency.Models.DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Tests.TruckServiceTest
{
    [TestClass]
    public class UpdateTruckShould
    {
        [TestMethod]
        public async Task UpdateTruckShould_ChangeTruckContents()
        {
            //Arange
            var testContext = AgencyTestUtils.GenerateContext();
            var sut = new TruckService(testContext);
            var testTruck = testContext.Trucks.First();
            var testTruckDTO = testTruck.ToDTO();
            testTruckDTO.PassengerCapacity =-  1;
            
            //Act
            await sut.UpdateTruckAsync(testTruck.ID, testTruckDTO);

            //Assert 
            Assert.AreEqual(testTruck.PassengerCapacity, testTruckDTO.PassengerCapacity);

        }
    }
}
