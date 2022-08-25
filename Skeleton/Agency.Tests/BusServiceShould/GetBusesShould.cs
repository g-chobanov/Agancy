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
    public class GetBusesShould
    {
        [TestMethod]
        public async Task GetBusesShould_ReturnListOfBuses()
        {
            //Arange
            var testContext = AgencyTestUtils.GenerateContext();
            var sut = new BusService(testContext);

            //Act
            var actualBuses = await sut.GetBusesAsync();

            //Assert
            CollectionAssert.AreEqual(testContext.Buses.Select(t => t.ID).ToList(), actualBuses.Select(t => t.ID).ToList());
        }
    }
}
