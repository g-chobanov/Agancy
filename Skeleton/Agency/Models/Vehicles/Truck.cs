﻿using Agency.Models.Vehicles.Contracts;
using Agency.Models.Vehicles.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Agency.Models.Vehicles
{
    public class Truck : ITruck
    {

        [Range(IVehicle._minPassengers, IVehicle._maxPassengers, ErrorMessage = "A vehicle with less than {1} passengers or more than {2} passengers cannot exist!")]
        public int PassengerCapacity { get; set; }

        [Range(((double)IVehicle._minPricePerKillometer), ((double)IVehicle._maxPricePerKillometer), ErrorMessage = "A vehicle with a price per kilometer lower than $0.10 or higher than $2.50 cannot exist!")]
        public decimal PricePerKilometer { get; set; }

        public VehicleType Type => VehicleType.Land;

        public int Storage { get; set; }

        public override string ToString()
        {
            string format = "Truck ----" + Environment.NewLine +
                            $"Passenger capacity: {PassengerCapacity}" + Environment.NewLine +
                            $"Price per kilometer: {PricePerKilometer}" + Environment.NewLine +
                            $"Vehicle type: {Type}" + Environment.NewLine +
                            $"Storage: {Storage}";

            return format.Replace(',', '.');
        }
    }
}