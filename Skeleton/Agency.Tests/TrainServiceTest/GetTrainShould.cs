using Agency.Core;
using Agency.Models.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Tests.TrainServiceTest
{
    [TestClass]
    public class GetTrainShould
    {
        [TestMethod]
        public async Task GetTrainShould_ReturnTrain()
        {
            //Arange
            var testContext = AgencyTestUtils.GenerateContext();
            var sut = new TrainService(testContext);
            var testID = AgencyTestUtils.trainID;

            //Act 
            var actualTrainDTO = await sut.GetTrainAsync(testID);

            //Assert
            Assert.IsNotNull(actualTrainDTO);
        }

        [TestMethod]
        public async Task GetTrainShould_ThrowArgumentNullExcpetion_OnGetNonExistingTrain()
        {
            //Arange
            var testContext = AgencyTestUtils.GenerateContext();
            var sut = new TrainService(testContext);
            var testID = Guid.NewGuid();

            //Act && Assert
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.GetTrainAsync(testID));
        }

    }
}
