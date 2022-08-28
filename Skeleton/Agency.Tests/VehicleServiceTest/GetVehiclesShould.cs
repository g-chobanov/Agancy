using Agency.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Tests.VehicleServiceTest
{
    [TestClass]
    public class GetVehiclesShould
    {
        [TestMethod]
        public async Task GetVehiclesShould_ReturnListOfVehicles()
        {
            //Arange
            var testContext = AgencyTestUtils.GenerateContext();
            var sut = new VehicleService(testContext);

            //Act
            var actualVehicles = await sut.GetVehiclesAsync();

            //Assert
            CollectionAssert.AreEqual(testContext.Vehicles.Select(t => t.ID).ToList(), actualVehicles.Select(t => t.ID).ToList());
        }
    }
}
