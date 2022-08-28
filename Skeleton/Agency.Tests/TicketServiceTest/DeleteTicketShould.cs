using Agency.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Tests.TicketServiceTest
{
    [TestClass]
    public class DeleteTicketsShould
    {
        [TestMethod]
        public async Task DeleteTicketsShould_RemoveTicket()
        {

            //Arange
            var testContext = AgencyTestUtils.GenerateContext();
            var sut = new TicketService(testContext);
            var testID = AgencyTestUtils.ticketID;

            //Act 
            await sut.DeleteTicketAsync(testID);
            var actualTicket = testContext.Tickets.FirstOrDefault(t => t.ID == testID);

            //Assert
            Assert.IsNull(actualTicket);
        }
        [TestMethod]
        public async Task DeleteTicketShould_ThrowArgumentNullExcpetion_OnGetNonExistingTicket()
        {
            //Arange
            var testContext = AgencyTestUtils.GenerateContext();
            var sut = new TicketService(testContext);
            var testID = Guid.NewGuid();

            //Act && Assert
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.DeleteTicketAsync(testID));
        }
    }
   
}
