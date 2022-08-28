﻿using Agency.Models.Vehicles.Contracts;
using Agency.Models.Vehicles.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Agency.Models.Enums;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;
using Agency.Models.Models.Vehicles;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agency.Models.Vehicles
{
    [Table("CargoShips")]
    public class CargoShip : Vehicle, ICargoShip
    {
        [Key]
        public override Guid ID { get; set; }

        [Range(IVehicle._minPassengers, IVehicle._maxPassengers, ErrorMessage = "A vehicle with less than {1} passengers or more than {2} passengers cannot exist!")]
        public override int PassengerCapacity { get; set; }

        [Range(((double)IVehicle._minPricePerKillometer), ((double)IVehicle._maxPricePerKillometer), ErrorMessage = "A vehicle with a price per kilometer lower than $0.10 or higher than $2.50 cannot exist!")]
        public override decimal PricePerKilometer { get; set; }
        public override VehicleType Type { get; set; }
        public override VehicleClassType ClassType => VehicleClassType.CargoShip;

        public int Storage { get; set; }
        public CargoShip()
        {
            ID = Guid.NewGuid();
        }

        public override string ToString()
        {
            string format = "CargoShip ----" + Environment.NewLine +
                            $"Passenger capacity: {PassengerCapacity}" + Environment.NewLine +
                            $"Price per kilometer: {PricePerKilometer}" + Environment.NewLine +
                            $"Vehicle type: {Type}" + Environment.NewLine +
                            $"Cargo: {Storage}";

            return format.Replace(',', '.');
        }
    }
}
