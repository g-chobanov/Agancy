using Agency.Core;
using Agency.Models.DTOMappers;
using Agency.Models.DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Tests.TicketServiceTest
{
    [TestClass]
    public class UpdateTicketShould
    {
        [TestMethod]
        public async Task UpdateTicketShould_ChangeTicketContents()
        {
            //Arange
            var testContext = AgencyTestUtils.GenerateContext();
            var sut = new TicketService(testContext);
            var testTicket = testContext.Tickets.First();
            var testTicketDTO = testTicket.ToDTO();
            testTicketDTO.AdministrativeCosts -= 1;
            
            //Act
            await sut.UpdateTicketAsync(testTicketDTO);

            //Assert 
            Assert.AreEqual(testTicket.AdministrativeCosts, testTicketDTO.AdministrativeCosts);

        }

        [TestMethod]
        public async Task UpdateTicketShould_ThrowArgumentNullExcpetion_OnGetNonExistingTicket()
        {
            //Arange
            var testContext = AgencyTestUtils.GenerateContext();
            var sut = new TicketService(testContext);
            var testID = Guid.NewGuid();
            var testDTO = new TicketDTO
            {
                ID = testID,
            };

            //Act && Assert
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.UpdateTicketAsync(testDTO));
        }
        public async Task UpdateTicketShould_ThrowArgumentNullExcpetion_OnGetNonExistingJourney()
        {
            //Arange
            var testContext = AgencyTestUtils.GenerateContext();
            var sut = new TicketService(testContext);
            var testID = AgencyTestUtils.ticketID;
            var testJourneyID = Guid.NewGuid();
            var testDTO = new TicketDTO
            {
                ID = testID,
                JourneyID = testJourneyID,
            };

            //Act && Assert
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.UpdateTicketAsync(testDTO));
        }
    }
}
