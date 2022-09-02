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
    public class DeleteVehicleShould
    {
        [TestMethod]
        public async Task DeleteVehiclesShould_RemoveVehicle()
        {

            //Arange
            var testContext = AgencyTestUtils.GenerateContext();
            var sut = new VehicleService(testContext);
            var testID = AgencyTestUtils.trainID;

            //Act 
            await sut.DeleteVehicleAsync(testID);
            var actualVehicle = testContext.Vehicles.FirstOrDefault(t => t.ID == testID);

            //Assert
            Assert.IsNull(actualVehicle);
        }
        [TestMethod]
        public async Task DeleteVehicleShould_ThrowArgumentNullExcpetion_OnGetNonExistingVehicle()
        {
            //Arange
            var testContext = AgencyTestUtils.GenerateContext();
            var sut = new VehicleService(testContext);
            var testID = Guid.NewGuid();

            //Act && Assert
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.DeleteVehicleAsync(testID));
        }
    }
}

