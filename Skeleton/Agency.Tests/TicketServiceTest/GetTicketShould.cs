using Agency.Core;
using Agency.Models.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Tests.TicketServiceTest
{
    [TestClass]
    public class GetTicketShould
    {
        [TestMethod]
        public async Task GetTicketShould_ReturnTicket()
        {
            //Arange
            var testContext = AgencyTestUtils.GenerateContext();
            var sut = new TicketService(testContext);
            var testID = AgencyTestUtils.ticketID;

            //Act 
            var actualTicketDTO = await sut.GetTicketAsync(testID);

            //Assert
            Assert.IsNotNull(actualTicketDTO);
        }

        [TestMethod]
        public async Task GetTicketShould_ThrowArgumentNullExcpetion_OnGetNonExistingTicket()
        {
            //Arange
            var testContext = AgencyTestUtils.GenerateContext();
            var sut = new TicketService(testContext);
            var testID = Guid.NewGuid();

            //Act && Assert
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.GetTicketAsync(testID));
        }

    }
}
