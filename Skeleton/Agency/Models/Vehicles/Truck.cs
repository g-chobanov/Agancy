using Agency.Models.Vehicles.Contracts;
using Agency.Models.Vehicles.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Agency.Models.Enums;
using System.Text.Json.Serialization;
using Agency.Models.Models.Vehicles;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agency.Models.Vehicles
{
    [Table("Trucks")]
    public class Truck : Vehicle, ITruck
    {
        [Key]
        public override Guid ID { get; set; }

        public override int PassengerCapacity { get; set; }

        public override decimal PricePerKilometer { get; set; }

        public override VehicleType Type { get; set; }

        public override VehicleClassType ClassType => VehicleClassType.Truck;

        public int Storage { get; set; }

        public Truck()
        {
            ID = Guid.NewGuid();
        }

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
