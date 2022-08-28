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
    public class GetTicketsShould
    {
        [TestMethod]
        public async Task GetTicketsShould_ReturnListOfTickets()
        {
            //Arange
            var testContext = AgencyTestUtils.GenerateContext();
            var sut = new TicketService(testContext);

            //Act
            var actualTickets = await sut.GetTicketsAsync();

            //Assert
            CollectionAssert.AreEqual(testContext.Tickets.Select(t => t.ID).ToList(), actualTickets.Select(t => t.ID).ToList());
        }
    }
}
