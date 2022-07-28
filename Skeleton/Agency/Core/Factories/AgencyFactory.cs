using System;
using Agency.Core.Contracts;
using Agency.Models;
using Agency.Models.Classes;
using Agency.Models.Contracts;
using Agency.Models.Vehicles;
using Agency.Models.Vehicles.Contracts;

namespace Agency.Core.Factories
{
    public class AgencyFactory : IAgencyFactory
    {
        private static IAgencyFactory instanceHolder = new AgencyFactory();

        private AgencyFactory()
        {
        }

        public static IAgencyFactory Instance
        {
            get
            {
                return instanceHolder;
            }
        }
        
        public IBus CreateBus(int passengerCapacity, decimal pricePerKilometer)
        {
            var newBus = new Bus
            {
                PassengerCapacity = passengerCapacity,
                PricePerKilometer = pricePerKilometer
            };
            ValidatorUtility.ValidateAnnotations(newBus);
            return newBus;
            
        }

        public IAirplane CreateAirplane(int passengerCapacity, decimal pricePerKilometer, bool hasFreeFood)
        {
            var newAirplane = new Airplane
            {
                PassengerCapacity = passengerCapacity,
                PricePerKilometer = pricePerKilometer,
                HasFreeFood = hasFreeFood
            };
            ValidatorUtility.ValidateAnnotations(newAirplane);
            return newAirplane;
        }

        public ITrain CreateTrain(int passengerCapacity, decimal pricePerKilometer, int carts)
        {
            var newTrain = new Train   
            {
                PassengerCapacity = passengerCapacity,
                PricePerKilometer = pricePerKilometer,
                Carts = carts,
            };
            ValidatorUtility.ValidateAnnotations(newTrain);
            return newTrain;
        }
        
        public IJourney CreateJourney(string startLocation, string destination, int distance, IVehicle vehicle)
        {
            var newJourney = new Journey
            {
                StartLocation = startLocation,
                Destination = destination,
                Distance = distance,
                Vehicle = vehicle

            };
            ValidatorUtility.ValidateAnnotations(newJourney);
            return newJourney;
        }

        public ITicket CreateTicket(IJourney journey, decimal administrativeCosts)
        {
            var newTicket = new Ticket
            { 
                Journey = journey, 
                AdministrativeCosts = administrativeCosts 
            };
            ValidatorUtility.ValidateAnnotations(newTicket);
            return newTicket;
        }

        public ITruck CreateTruck(int passengerCapacity, decimal pricePerKilometer, int storage)
        {
            var newTruck = new Truck
            {
                PassengerCapacity = passengerCapacity,
                PricePerKilometer = pricePerKilometer,
                Storage = storage
            };
            ValidatorUtility.ValidateAnnotations(newTruck);
            return newTruck;
        }

        public ICargoShip CreateCargoShip(int passengerCapacity, decimal pricePerKilometer, double cargo)
        {
            var newCargoShip = new CargoShip
            {
                PassengerCapacity = passengerCapacity,
                PricePerKilometer = pricePerKilometer,
                Cargo = cargo
            };
            ValidatorUtility.ValidateAnnotations(newCargoShip);
            return newCargoShip;
        }
    }
}
