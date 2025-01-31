using BusinessModel.Models;

namespace BusinessModel.Contracts
{
    public interface IVehicleService
    {
        void AddVehicle(AutoMobile vehicle);
        bool DeleteVehicle(Guid id);
        AutoMobile? GetVehicle(Guid id);
        IEnumerable<AutoMobile> GetVehicles();
        bool UpdateVehicle(Guid id, AutoMobile vehicle);
    }
}