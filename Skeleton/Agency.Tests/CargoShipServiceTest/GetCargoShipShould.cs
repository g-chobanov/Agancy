using Agency.Core;
using Agency.Models.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Tests.CargoShipServiceTest
{
    [TestClass]
    public class GetCargoShipShould
    {
        [TestMethod]
        public async Task GetCargoShipShould_ReturnCargoShip()
        {
            //Arange
            var testContext = AgencyTestUtils.GenerateContext();
            var sut = new CargoShipService(testContext);
            var testID = AgencyTestUtils.cargoShipID;

            //Act 
            var actualCargoShipDTO = await sut.GetCargoShipAsync(testID);

            //Assert
            Assert.IsNotNull(actualCargoShipDTO);
        }

        [TestMethod]
        public async Task GetCargoShipShould_ThrowArgumentNullExcpetion_OnGetNonExistingCargoShip()
        {
            //Arange
            var testContext = AgencyTestUtils.GenerateContext();
            var sut = new CargoShipService(testContext);
            var testID = Guid.NewGuid();

            //Act && Assert
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.GetCargoShipAsync(testID));
        }

    }
}
