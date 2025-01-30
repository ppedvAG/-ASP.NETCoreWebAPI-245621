using BusinessModel.Contracts;
using BusinessModel.Models;
using System.Drawing;

namespace BusinessModel.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly List<AutoMobile> _vehicles = new List<AutoMobile>
        {
            new AutoMobile
            {
                Id = 1,
                Manufacturer = "Audi",
                Model = "A4",
                TopSpeed = 200,
                Fuel = "Diesel",
                Color = KnownColor.LimeGreen,
                Type = "Sedan",
                RegistritationDate = new DateTime(2005, 5, 1)
            },
        };

        public VehicleService()
        {
        }

        public IEnumerable<AutoMobile> GetVehicles()
        {
            return _vehicles.ToArray();
        }

        public AutoMobile? GetVehicle(long id)
        {
            return _vehicles.SingleOrDefault(v => v.Id == id);
        }

        public void AddVehicle(AutoMobile vehicle)
        {
            _vehicles.Add(vehicle);
        }

        public bool UpdateVehicle(long id, AutoMobile vehicle)
        {
            var existing = _vehicles.SingleOrDefault(v => v.Id == id);
            if (existing != null)
            {
                existing.Manufacturer = vehicle.Manufacturer;
                existing.Model = vehicle.Model;
                existing.TopSpeed = vehicle.TopSpeed;
                existing.Fuel = vehicle.Fuel;
                existing.Color = vehicle.Color;
                existing.Type = vehicle.Type;
                existing.RegistritationDate = vehicle.RegistritationDate;
                return true;
            }
            return false;
        }

        public bool DeleteVehicle(long id)
        {
            var vehicle = _vehicles.SingleOrDefault(v => v.Id == id);
            if (vehicle != null)
            {
                _vehicles.Remove(vehicle);
                return true;
            }
            return false;
        }
    }
}
