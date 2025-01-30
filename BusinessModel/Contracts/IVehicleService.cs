using BusinessModel.Models;

namespace BusinessModel.Contracts
{
    public interface IVehicleService
    {
        void AddVehicle(AutoMobile vehicle);
        bool DeleteVehicle(long id);
        AutoMobile? GetVehicle(long id);
        IEnumerable<AutoMobile> GetVehicles();
        bool UpdateVehicle(long id, AutoMobile vehicle);
    }
}