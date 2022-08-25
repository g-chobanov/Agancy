using Agency.Core;
using Agency.Models.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Tests.BusServiceTest
{
    [TestClass]
    public class GetBusShould
    {
        [TestMethod]
        public async Task GetBusShould_ReturnBus()
        {
            //Arange
            var testContext = AgencyTestUtils.GenerateContext();
            var sut = new BusService(testContext);
            var testID = AgencyTestUtils.busID;

            //Act 
            var actualBusDTO = await sut.GetBusAsync(testID);

            //Assert
            Assert.IsNotNull(actualBusDTO);
        }

        [TestMethod]
        public async Task GetBusShould_ThrowArgumentNullExcpetion_OnGetNonExistingBus()
        {
            //Arange
            var testContext = AgencyTestUtils.GenerateContext();
            var sut = new BusService(testContext);
            var testID = Guid.NewGuid();

            //Act && Assert
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.GetBusAsync(testID));
        }

    }
}
