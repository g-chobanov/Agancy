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
    public class DeleteTrainsShould
    {
        [TestMethod]
        public async Task DeleteTrainsShould_RemoveTrain()
        {

            //Arange
            var testContext = AgencyTestUtils.GenerateContext();
            var sut = new TrainService(testContext);
            var testID = AgencyTestUtils.trainID;

            //Act 
            await sut.DeleteTrainAsync(testID);
            var actualTrain = testContext.Trains.FirstOrDefault(t => t.ID == testID);

            //Assert
            Assert.IsNull(actualTrain);
        }
        [TestMethod]
        public async Task DeleteTrainShould_ThrowArgumentNullExcpetion_OnGetNonExistingTrain()
        {
            //Arange
            var testContext = AgencyTestUtils.GenerateContext();
            var sut = new TrainService(testContext);
            var testID = Guid.NewGuid();

            //Act && Assert
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.DeleteTrainAsync(testID));
        }
    }
   
}
