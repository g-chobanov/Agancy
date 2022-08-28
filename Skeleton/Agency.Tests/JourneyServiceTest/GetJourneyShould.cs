using Agency.Core;
using Agency.Models.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Tests.JourneyServiceTest
{
    [TestClass]
    public class GetJourneyShould
    {
        [TestMethod]
        public async Task GetJourneyShould_ReturnJourney()
        {
            //Arange
            var testContext = AgencyTestUtils.GenerateContext();
            var sut = new JourneyService(testContext);
            var testID = AgencyTestUtils.journeyID;

            //Act 
            var actualJourneyDTO = await sut.GetJourneyAsync(testID);

            //Assert
            Assert.IsNotNull(actualJourneyDTO);
        }

        [TestMethod]
        public async Task GetJourneyShould_ThrowArgumentNullExcpetion_OnGetNonExistingJourney()
        {
            //Arange
            var testContext = AgencyTestUtils.GenerateContext();
            var sut = new JourneyService(testContext);
            var testID = Guid.NewGuid();

            //Act && Assert
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.GetJourneyAsync(testID));
        }

    }
}
