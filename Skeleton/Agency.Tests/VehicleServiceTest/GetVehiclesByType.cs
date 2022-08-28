using Agency.Core;
using Agency.Models.Vehicles.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Tests.VehicleServiceTest
{
    public class GetVehiclesByType
    {
        [TestMethod]
        public async Task GetVehiclesShould_ReturnListOfVehicles()
        {
            //Arange
            var testContext = AgencyTestUtils.GenerateContext();
            var sut = new VehicleService(testContext);
            var testType = VehicleType.Land;

            //Act
            var actualVehicles = await sut.GetVehiclesByTypeAsync(testType);

            //Assert
            CollectionAssert.AreEqual(testContext.Vehicles.Where(t => t.Type == testType).Select(t => t.ID).ToList(), actualVehicles.Select(t => t.ID).ToList());
        }
    }
}
