using BusinessModel.Models;
using RentACar.Models;
using System.Drawing;

namespace RentACarApi.Mappers
{
    /// <summary>
    /// Mapper welche sog. Extension Methoden verwendet.
    /// Der erste Parameter enthaelt das this Keyword wodurch wir die Methoden des Dto bzw. Entities normal verwenden koennen. 
    /// </summary>
    public static class VehicleMapper
    {
        public static VehicleResultDto ToVehicleDto(this AutoMobile vehicle)
        {
            return new VehicleResultDto
            {
                Id = vehicle.Id,
                Manufacturer = vehicle.Manufacturer,
                Model = vehicle.Model,
                Type = vehicle.Type,
                Fuel = vehicle.Fuel,
                Color = vehicle.Color.ToString(),
                TopSpeed = vehicle.TopSpeed + " km/h",
                RegistritationDate = vehicle.RegistritationDate.ToString("MM/yyyy"),
            };
        }

        public static AutoMobile ToEntity(this VehicleDto vehicle)
        {
            KnownColor color = Enum.TryParse(vehicle.Color, out color) ? color : KnownColor.White;

            int topSpeed = int.TryParse(vehicle.TopSpeed, out topSpeed) ? topSpeed : 100;

            DateTime.TryParse(vehicle.RegistritationDate, out var registritationDate);

            return new AutoMobile
            {
                Manufacturer = vehicle.Manufacturer,
                Model = vehicle.Model,
                Type = vehicle.Type ?? "Default",
                Fuel = vehicle.Fuel ?? "Gasoline",
                Color = color,
                TopSpeed = topSpeed,
                RegistritationDate = registritationDate
            };
        }
    }
}
