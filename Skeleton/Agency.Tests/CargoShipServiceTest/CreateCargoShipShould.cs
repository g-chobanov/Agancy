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

namespace Agency.Tests.CargoShipServiceTest
{
    [TestClass]
    public class CreateCargoShipShould
    {
        [TestMethod]
        public async Task CreateAriplaneShould_AddNewCargoShip()
        {
            //Arange
            var testContext = new AgencyDatabaseContext(AgencyTestUtils.GetOptions());
            var sut = new CargoShipService(testContext);
            int testCap = 30;
            decimal testPPK = 1.7m;
            int testStorage = 20;
            var testCargoShip = new CargoShipDTO
            {
                PassengerCapacity = testCap,
                PricePerKilometer = testPPK,
                Storage = testStorage
            };

            //Act 
            await sut.AddCargoShipAsync(testCargoShip);
            var acutalCargoShip = testContext.CargoShips.FirstOrDefault(t => t.PassengerCapacity == testCap && t.PricePerKilometer == testPPK && t.Storage == testStorage);

            //Assert
            Assert.IsNotNull(acutalCargoShip);
            Assert.AreEqual(VehicleType.Sea, acutalCargoShip.Type);
        }

    }
}
