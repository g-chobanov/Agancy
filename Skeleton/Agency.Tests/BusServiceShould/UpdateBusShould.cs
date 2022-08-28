using Agency.Core;
using Agency.Models.DTOMappers;
using Agency.Models.DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Tests.BusServiceTest
{
    [TestClass]
    public class UpdateBusShould
    {
        [TestMethod]
        public async Task UpdateBusShould_ChangeBusContents()
        {
            //Arange
            var testContext = AgencyTestUtils.GenerateContext();
            var sut = new BusService(testContext);
            var testBus = testContext.Buses.First();
            var testBusDTO = testBus.ToDTO();
            testBusDTO.PassengerCapacity =-  1;
            
            //Act
            await sut.UpdateBusAsync(testBusDTO);

            //Assert 
            Assert.AreEqual(testBus.PassengerCapacity, testBusDTO.PassengerCapacity);

        }

        [TestMethod]
        public async Task UpdateBusShould_ThrowArgumentNullExcpetion_OnGetNonExistingBus()
        {
            //Arange
            var testContext = AgencyTestUtils.GenerateContext();
            var sut = new BusService(testContext);
            var testID = Guid.NewGuid();
            var testDTO = new BusDTO
            {
                ID = testID,
            };

            //Act && Assert
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.UpdateBusAsync(testDTO));
        }
    }
}
