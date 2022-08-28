using System;
using System.Collections.Generic;
using System.Text;
using Agency.Models.Vehicles.Contracts;
using Agency.Models.Vehicles.Enums;
using System.ComponentModel.DataAnnotations;
using Agency.Models.Enums;
using System.Text.Json.Serialization;
using Agency.Models.Models.Vehicles;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agency.Models.Vehicles
{
    [Table("Airplanes")]
    public class Airplane : Vehicle, IAirplane
    {
        [Key]
        public override Guid ID { get; set; }

        public override int PassengerCapacity { get; set; }

        [Range(((double)IVehicle._minPricePerKillometer), ((double)IVehicle._maxPricePerKillometer), ErrorMessage = "A vehicle with a price per kilometer lower than $0.10 or higher than $2.50 cannot exist!")]
        public override decimal PricePerKilometer { get; set; }

        public bool HasFreeFood { get; set;  }

        public override VehicleType Type { get; set; }

        public override VehicleClassType ClassType => VehicleClassType.Airplane;

        public override string ToString()
        {

            string format = "Airplane ----" + Environment.NewLine +
                            $"Passenger capacity: {PassengerCapacity}" + Environment.NewLine +
                            $"Price per kilometer: {PricePerKilometer}" + Environment.NewLine +
                            $"Vehicle type: {Type}" + Environment.NewLine +
                            $"Has free food: {HasFreeFood}";


            return format.Replace(',', '.');
        }
    }
}
