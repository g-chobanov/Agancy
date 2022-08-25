using Agency.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Tests.AirplaneServiceTest
{
    [TestClass]
    public class DeleteAirplanesShould
    {
        [TestMethod]
        public async Task DeleteAirplanesShould_RemoveAirplane()
        {

            //Arange
            var testContext = AgencyTestUtils.GenerateContext();
            var sut = new AirplaneService(testContext);
            var testID = AgencyTestUtils.airplaneID;

            //Act 
            await sut.DeleteAirplaneAsync(testID);
            var actualAirplane = testContext.Airplanes.FirstOrDefault(t => t.ID == testID);

            //Assert
            Assert.IsNull(actualAirplane);
        }
        [TestMethod]
        public async Task DeleteAirplaneShould_ThrowArgumentNullExcpetion_OnGetNonExistingAirplane()
        {
            //Arange
            var testContext = AgencyTestUtils.GenerateContext();
            var sut = new AirplaneService(testContext);
            var testID = Guid.NewGuid();

            //Act && Assert
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.DeleteAirplaneAsync(testID));
        }
    }
   
}
