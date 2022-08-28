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
    public class GetPriceShould
    {
        [TestMethod]
        public async Task GetPriceShould_ReturnPrice()
        {
            //Arange
            var testContext = AgencyTestUtils.GenerateContext();
            var sut = new TicketService(testContext);
            var testTicket = testContext.Tickets.FirstOrDefault(t => t.ID == AgencyTestUtils.ticketID);
            //Act 
            var price = await sut.GetPriceAsync(testTicket.ID);
            //Assert
            Assert.AreEqual(testTicket.CalculatePrice(), price);
        }
    }
}
