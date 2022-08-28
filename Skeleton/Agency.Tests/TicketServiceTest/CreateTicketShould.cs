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

namespace Agency.Tests.TicketServiceTest
{
    [TestClass]
    public class CreateTicketShould
    {
        [TestMethod]
        public async Task CreateTicketShould_AddNewTicket()
        {
            //Arange
            var testContext = AgencyTestUtils.GenerateContext();
            var sut = new TicketService(testContext);
            int testCosts = 10;
            var testJourneyId = AgencyTestUtils.journeyID;
            var testTicket = new TicketDTO
            {
                AdministrativeCosts = testCosts,
                JourneyID = testJourneyId,
            };

            //Act 
            await sut.CreateTicketAsync(testTicket);
            var actualTicket = testContext.Tickets.FirstOrDefault(t => t.AdministrativeCosts == testCosts && t.JourneyID == testJourneyId);

            //Assert
            Assert.IsNotNull(actualTicket);
        }

        [TestMethod]
        public async Task CreateTicketShould_ReturnFalse_OnGetNonExistingJourney()
        {
            //Arange
            var testContext = AgencyTestUtils.GenerateContext();
            var sut = new TicketService(testContext);
            var testID = Guid.NewGuid();
            var testTicket = new TicketDTO
            {
                JourneyID = testID,
            };

            //Act 
            var result = await sut.CreateTicketAsync(testTicket);

            //Assert
            Assert.IsFalse(result);
        }

    }
}
