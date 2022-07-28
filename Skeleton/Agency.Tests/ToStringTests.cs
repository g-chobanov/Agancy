using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Agency.Models.Vehicles.VehicleClasses;

namespace Agency.Tests
{
    [TestClass]
    public class ToStringTests
    {
        [TestMethod]
        public void TrainToString()
        {
            int passengers = 40;
            int carts = 7;
            decimal pricePerKm = 2.10m;
            Train train = new Train(passengers, pricePerKm, carts);
            string test = "Train ----\n" +
                           $"Passenger capacity: {passengers}\n" +
                           $"Price per kilometer: {pricePerKm}\n" +
                           $"Vehicle type: Land\n" +
                           $"Carts amount: {carts}";

            string format = train.ToString();

            Console.WriteLine(format);

            Assert.AreEqual(test, format);


        }
    }
}
