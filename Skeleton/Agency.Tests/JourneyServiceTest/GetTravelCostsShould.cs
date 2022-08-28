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
    public class GetTravelCostsShould
    {
        [TestMethod]
        public async Task GetPriceShould_ReturnPrice()
        {
            //Arange
            var testContext = AgencyTestUtils.GenerateContext();
            var sut = new JourneyService(testContext);
            var testJourney = testContext.Journeys.FirstOrDefault(t => t.ID == AgencyTestUtils.journeyID);
            //Act 
            var travelCosts = await sut.GetTravelCostsAsync(testJourney.ID);
            //Assert
            Assert.AreEqual(testJourney.CalculateTravelCosts(), travelCosts);
        }
    }
}
