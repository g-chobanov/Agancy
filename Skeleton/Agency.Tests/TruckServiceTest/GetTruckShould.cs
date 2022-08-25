using Agency.Core;
using Agency.Models.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Tests.TruckServiceTest
{
    [TestClass]
    public class GetTruckShould
    {
        [TestMethod]
        public async Task GetTruckShould_ReturnTruck()
        {
            //Arange
            var testContext = AgencyTestUtils.GenerateContext();
            var sut = new TruckService(testContext);
            var testID = AgencyTestUtils.truckID;

            //Act 
            var actualTruckDTO = await sut.GetTruckAsync(testID);

            //Assert
            Assert.IsNotNull(actualTruckDTO);
        }

        [TestMethod]
        public async Task GetTruckShould_ThrowArgumentNullExcpetion_OnGetNonExistingTruck()
        {
            //Arange
            var testContext = AgencyTestUtils.GenerateContext();
            var sut = new TruckService(testContext);
            var testID = Guid.NewGuid();

            //Act && Assert
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.GetTruckAsync(testID));
        }

    }
}
