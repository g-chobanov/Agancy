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
    public class GetAirplanesShould
    {
        [TestMethod]
        public async Task GetAirplanesShould_ReturnListOfAirplanes()
        {
            //Arange
            var testContext = AgencyTestUtils.GenerateContext();
            var sut = new AirplaneService(testContext);

            //Act
            var actualAirplanes = await sut.GetAirplanesAsync();

            //Assert
            CollectionAssert.AreEqual(testContext.Airplanes.Select(t => t.ID).ToList(), actualAirplanes.Select(t => t.ID).ToList());
        }
    }
}
