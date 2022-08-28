using Agency.Core;
using Agency.Models.DTOMappers;
using Agency.Models.DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Tests.JourneyServiceTest
{
    [TestClass]
    public class UpdateJourneyShould
    {
        [TestMethod]
        public async Task UpdateJourneyShould_ChangeJourneyContents()
        {
            //Arange
            var testContext = AgencyTestUtils.GenerateContext();
            var sut = new JourneyService(testContext);
            var testJourney = testContext.Journeys.First();
            var testJourneyDTO = testJourney.ToDTO();
            testJourneyDTO.Distance -= 1;
            
            //Act
            await sut.UpdateJourneyAsync(testJourneyDTO);

            //Assert 
            Assert.AreEqual(testJourney.Distance, testJourneyDTO.Distance);

        }

        [TestMethod]
        public async Task UpdateJourneyShould_ThrowArgumentNullExcpetion_OnGetNonExistingJourney()
        {
            //Arange
            var testContext = AgencyTestUtils.GenerateContext();
            var sut = new JourneyService(testContext);
            var testID = Guid.NewGuid();
            var testDTO = new JourneyDTO
            {
                ID = testID,
            };

            //Act && Assert
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.UpdateJourneyAsync(testDTO));
        }

        public async Task UpdateJourneyShould_ThrowArgumentNullExcpetion_OnGetNonExistingVehicle()
        {
            //Arange
            var testContext = AgencyTestUtils.GenerateContext();
            var sut = new JourneyService(testContext);
            var testID = AgencyTestUtils.ticketID;
            var testVehicleID = Guid.NewGuid();
            var testDTO = new JourneyDTO
            {
                ID = testID,
                VehicleID = testVehicleID,
            };

            //Act && Assert
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.UpdateJourneyAsync(testDTO));
        }
    }
}
