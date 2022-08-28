using Agency.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Tests.JourneyServiceTest
{
    [TestClass]
    public class DeleteJourneysShould
    {
        [TestMethod]
        public async Task DeleteJourneysShould_RemoveJourney()
        {

            //Arange
            var testContext = AgencyTestUtils.GenerateContext();
            var sut = new JourneyService(testContext);
            var testID = AgencyTestUtils.journeyID;

            //Act 
            await sut.DeleteJourneyAsync(testID);
            var actualJourney = testContext.Journeys.FirstOrDefault(t => t.ID == testID);

            //Assert
            Assert.IsNull(actualJourney);
        }
        [TestMethod]
        public async Task DeleteJourneyShould_ThrowArgumentNullExcpetion_OnGetNonExistingJourney()
        {
            //Arange
            var testContext = AgencyTestUtils.GenerateContext();
            var sut = new JourneyService(testContext);
            var testID = Guid.NewGuid();

            //Act && Assert
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.DeleteJourneyAsync(testID));
        }
    }
   
}
