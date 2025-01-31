using BusinessModel.Contracts;
using BusinessModel.Data;
using BusinessModel.Models;

namespace BusinessModel.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly VehicleDbContext context;

        public VehicleService(VehicleDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<AutoMobile> GetVehicles()
        {
            return context.Vehicles.ToArray();
        }

        public AutoMobile? GetVehicle(Guid id)
        {
            return context.Vehicles.SingleOrDefault(v => v.Id == id);
        }

        public void AddVehicle(AutoMobile vehicle)
        {
            context.Vehicles.Add(vehicle);
            context.SaveChanges();
        }

        public bool UpdateVehicle(Guid id, AutoMobile vehicle)
        {
            if (context.Vehicles.Any(v => v.Id == id))
            {
                context.Vehicles.Update(vehicle);

                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteVehicle(Guid id)
        {
            var vehicle = context.Vehicles.SingleOrDefault(v => v.Id == id);
            if (vehicle != null)
            {
                context.Vehicles.Remove(vehicle);
                context.SaveChanges();

                return true;
            }
            return false;
        }
    }
}
