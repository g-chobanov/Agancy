using Agency.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Tests.TruckServiceTest
{
    [TestClass]
    public class DeleteTrucksShould
    {
        [TestMethod]
        public async Task DeleteTrucksShould_RemoveTruck()
        {

            //Arange
            var testContext = AgencyTestUtils.GenerateContext();
            var sut = new TruckService(testContext);
            var testID = AgencyTestUtils.truckID;

            //Act 
            await sut.DeleteTruckAsync(testID);
            var actualTruck = testContext.Trucks.FirstOrDefault(t => t.ID == testID);

            //Assert
            Assert.IsNull(actualTruck);
        }
        [TestMethod]
        public async Task DeleteTruckShould_ThrowArgumentNullExcpetion_OnGetNonExistingTruck()
        {
            //Arange
            var testContext = AgencyTestUtils.GenerateContext();
            var sut = new TruckService(testContext);
            var testID = Guid.NewGuid();

            //Act && Assert
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.DeleteTruckAsync(testID));
        }
    }
   
}
