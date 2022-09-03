using Agency.Models.Vehicles.Contracts;
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
        public override int PassengerCapacity { get; set; }
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
