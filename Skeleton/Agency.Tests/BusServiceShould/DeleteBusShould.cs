using Agency.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Tests.BusServiceTest
{
    [TestClass]
    public class DeleteBusesShould
    {
        [TestMethod]
        public async Task DeleteBusesShould_RemoveBus()
        {

            //Arange
            var testContext = AgencyTestUtils.GenerateContext();
            var sut = new BusService(testContext);
            var testID = AgencyTestUtils.busID;

            //Act 
            await sut.DeleteBusAsync(testID);
            var actualBus = testContext.Buses.FirstOrDefault(t => t.ID == testID);

            //Assert
            Assert.IsNull(actualBus);
        }
        [TestMethod]
        public async Task DeleteBusShould_ThrowArgumentNullExcpetion_OnGetNonExistingBus()
        {
            //Arange
            var testContext = AgencyTestUtils.GenerateContext();
            var sut = new BusService(testContext);
            var testID = Guid.NewGuid();

            //Act && Assert
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.DeleteBusAsync(testID));
        }
    }
   
}
