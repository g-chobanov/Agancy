using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Text;
using Agency.Core;
using Agency.Models.Vehicles;
using Agency.Models.Classes;

namespace Agency.Tests
{
    [TestClass]
    public class DatabaseTests
    {
        [TestMethod]
        public void AddVehicle()
        {
            AgencyDatabase agencyDatabase = new AgencyDatabase();

            agencyDatabase.Add(new Bus { PassengerCapacity = 10, PricePerKilometer = 2.3m });

            Assert.AreEqual(1, agencyDatabase.Vehicles.Count);
        }
        [TestMethod]
        public void AddJourney()
        {
            AgencyDatabase agencyDatabase = new AgencyDatabase();

            agencyDatabase.Add(new Journey { Destination = "testland", 
                                            Distance = 10,
                                            StartLocation = "testtown", 
                                            Vehicle = new Bus 
                                            { 
                                                PassengerCapacity = 10, 
                                                PricePerKilometer = 2.3m 
                                            } });

            Assert.AreEqual(1, agencyDatabase.Journeys.Count);
        }
        [TestMethod]
        public void AddTicket()
        {
            AgencyDatabase agencyDatabase = new AgencyDatabase();

            agencyDatabase.Add(new Ticket { Journey = new Journey 
                                            { 
                                              Destination = "testland", 
                                              Distance = 10, 
                                              StartLocation = "testtown", 
                                              Vehicle = new Bus 
                                              { 
                                                  PassengerCapacity = 10, 
                                                  PricePerKilometer = 2.3m
                                              }
                                            },
                                            AdministrativeCosts = 20.3m });

            Assert.AreEqual(1, agencyDatabase.Tickets.Count);
        }
    }
}
