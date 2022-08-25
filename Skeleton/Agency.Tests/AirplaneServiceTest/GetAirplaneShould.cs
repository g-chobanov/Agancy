using Agency.Core;
using Agency.Models.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Tests.AirplaneServiceTest
{
    [TestClass]
    public class GetAirplaneShould
    {
        [TestMethod]
        public async Task GetAirplaneShould_ReturnAirplane()
        {
            //Arange
            var testContext = AgencyTestUtils.GenerateContext();
            var sut = new AirplaneService(testContext);
            var testID = AgencyTestUtils.airplaneID;

            //Act 
            var actualAirplaneDTO = await sut.GetAirplaneAsync(testID);

            //Assert
            Assert.IsNotNull(actualAirplaneDTO);
        }

        [TestMethod]
        public async Task GetAirplaneShould_ThrowArgumentNullExcpetion_OnGetNonExistingAirplane()
        {
            //Arange
            var testContext = AgencyTestUtils.GenerateContext();
            var sut = new AirplaneService(testContext);
            var testID = Guid.NewGuid();

            //Act && Assert
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.GetAirplaneAsync(testID));
        }

    }
}
