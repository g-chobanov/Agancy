using Agency.Core;
using Agency.Models.DTOMappers;
using Agency.Models.DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Tests.CargoShipServiceTest
{
    [TestClass]
    public class UpdateCargoShipShould
    {
        [TestMethod]
        public async Task UpdateCargoShipShould_ChangeCargoShipContents()
        {
            //Arange
            var testContext = AgencyTestUtils.GenerateContext();
            var sut = new CargoShipService(testContext);
            var testCargoShip = testContext.CargoShips.First();
            var testCargoShipDTO = testCargoShip.ToDTO();
            testCargoShipDTO.PassengerCapacity =-  1;
            
            //Act
            await sut.UpdateCargoShipAsync(testCargoShipDTO);

            //Assert 
            Assert.AreEqual(testCargoShip.PassengerCapacity, testCargoShipDTO.PassengerCapacity);

        }

        [TestMethod]
        public async Task UpdateCargoShipShould_ThrowArgumentNullExcpetion_OnGetNonExistingCargoShip()
        {
            //Arange
            var testContext = AgencyTestUtils.GenerateContext();
            var sut = new CargoShipService(testContext);
            var testID = Guid.NewGuid();
            var testDTO = new CargoShipDTO
            {
                ID = testID,
            };

            //Act && Assert
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.UpdateCargoShipAsync(testDTO));
        }
    }
}
