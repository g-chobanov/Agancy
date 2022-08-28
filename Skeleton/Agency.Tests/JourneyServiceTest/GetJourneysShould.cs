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
    public class GetJourneysShould
    {
        [TestMethod]
        public async Task GetJourneysShould_ReturnListOfJourneys()
        {
            //Arange
            var testContext = AgencyTestUtils.GenerateContext();
            var sut = new JourneyService(testContext);

            //Act
            var actualJourneys = await sut.GetJourneysAsync();

            //Assert
            CollectionAssert.AreEqual(testContext.Journeys.Select(t => t.ID).ToList(), actualJourneys.Select(t => t.ID).ToList());
        }
    }
}
