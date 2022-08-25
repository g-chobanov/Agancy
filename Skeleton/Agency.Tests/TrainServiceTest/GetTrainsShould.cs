using Agency.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Tests.TrainServiceTest
{
    [TestClass]
    public class GetTrainsShould
    {
        [TestMethod]
        public async Task GetTrainsShould_ReturnListOfTrains()
        {
            //Arange
            var testContext = AgencyTestUtils.GenerateContext();
            var sut = new TrainService(testContext);

            //Act
            var actualTrains = await sut.GetTrainsAsync();

            //Assert
            CollectionAssert.AreEqual(testContext.Trains.Select(t => t.ID).ToList(), actualTrains.Select(t => t.ID).ToList());
        }
    }
}
