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
    public class GetCargoShipsShould
    {
        [TestMethod]
        public async Task GetCargoShipsShould_ReturnListOfCargoShips()
        {
            //Arange
            var testContext = AgencyTestUtils.GenerateContext();
            var sut = new CargoShipService(testContext);

            //Act
            var actualCargoShips = await sut.GetCargoShipsAsync();

            //Assert
            CollectionAssert.AreEqual(testContext.CargoShips.Select(t => t.ID).ToList(), actualCargoShips.Select(t => t.ID).ToList());
        }
    }
}
