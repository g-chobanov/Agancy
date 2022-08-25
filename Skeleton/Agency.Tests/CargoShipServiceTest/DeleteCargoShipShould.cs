using Agency.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Tests.CargoShipServiceTest
{
    [TestClass]
    public class DeleteCargoShipsShould
    {
        [TestMethod]
        public async Task DeleteCargoShipsShould_RemoveCargoShip()
        {

            //Arange
            var testContext = AgencyTestUtils.GenerateContext();
            var sut = new CargoShipService(testContext);
            var testID = AgencyTestUtils.cargoShipID;

            //Act 
            await sut.DeleteCargoShipAsync(testID);
            var actualCargoShip = testContext.CargoShips.FirstOrDefault(t => t.ID == testID);

            //Assert
            Assert.IsNull(actualCargoShip);
        }
        [TestMethod]
        public async Task DeleteCargoShipShould_ThrowArgumentNullExcpetion_OnGetNonExistingCargoShip()
        {
            //Arange
            var testContext = AgencyTestUtils.GenerateContext();
            var sut = new CargoShipService(testContext);
            var testID = Guid.NewGuid();

            //Act && Assert
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.DeleteCargoShipAsync(testID));
        }
    }
   
}
