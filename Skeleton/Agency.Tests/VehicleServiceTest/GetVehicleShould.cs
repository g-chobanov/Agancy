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
    public class GetVehicleShould
    {
        [TestMethod]
        public async Task GetVehicleShould_ReturnVehicle()
        {
            //Arange
            var testContext = AgencyTestUtils.GenerateContext();
            var sut = new VehicleService(testContext);
            var testID = AgencyTestUtils.busID;

            //Act 
            var actualVehicleDTO = await sut.GetVehicleAsync(testID);

            //Assert
            Assert.IsNotNull(actualVehicleDTO);
        }

        [TestMethod]
        public async Task GetVehicleShould_ThrowArgumentNullExcpetion_OnGetNonExistingVehicle()
        {
            //Arange
            var testContext = AgencyTestUtils.GenerateContext();
            var sut = new VehicleService(testContext);
            var testID = Guid.NewGuid();

            //Act && Assert
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.GetVehicleAsync(testID));
        }
    }
}
