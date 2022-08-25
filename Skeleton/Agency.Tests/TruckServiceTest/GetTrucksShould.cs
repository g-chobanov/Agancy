using Agency.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Tests.TruckServiceTest
{
    [TestClass]
    public class GetTrucksShould
    {
        [TestMethod]
        public async Task GetTrucksShould_ReturnListOfTrucks()
        {
            //Arange
            var testContext = AgencyTestUtils.GenerateContext();
            var sut = new TruckService(testContext);

            //Act
            var actualTrucks = await sut.GetTrucksAsync();

            //Assert
            CollectionAssert.AreEqual(testContext.Trucks.Select(t => t.ID).ToList(), actualTrucks.Select(t => t.ID).ToList());
        }
    }
}
