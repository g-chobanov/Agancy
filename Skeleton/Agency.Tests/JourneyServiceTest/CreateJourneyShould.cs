using Agency.Core;
using Agency.Models;
using Agency.Models.Data;
using Agency.Models.DTOMappers;
using Agency.Models.DTOs;
using Agency.Models.Vehicles;
using Agency.Models.Vehicles.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Tests.JourneyServiceTest
{
    [TestClass]
    public class CreateJourneyShould
    {
        [TestMethod]
        public async Task CreateAriplaneShould_AddNewJourney()
        {
            //Arange
            var testContext = AgencyTestUtils.GenerateContext();
            var sut = new JourneyService(testContext);
            int testDistance = 10;
            string testDestination = "testD";
            string testStart = "testS";
            Guid testVehicleID = AgencyTestUtils.airplaneID;
            var testJourneyId = AgencyTestUtils.journeyID;
            var testJourney = new JourneyDTO
            {
                Destination = testDestination,
                Distance = testDistance,
                StartLocation = testStart,
                VehicleID = testVehicleID,
            };

            //Act 
            await sut.CreateJourneyAsync(testJourney);
            var actualJourney = testContext.Journeys.FirstOrDefault(t => t.Destination == testDestination 
                                                                    && t.Distance == testDistance
                                                                    && t.StartLocation == testStart
                                                                    && t.VehicleId == testVehicleID);

            //Assert
            Assert.IsNotNull(actualJourney);
        }

    }
}
