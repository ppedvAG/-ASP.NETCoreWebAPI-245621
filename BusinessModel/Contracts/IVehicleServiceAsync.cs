using BusinessModel.Models;

namespace BusinessModel.Contracts
{
    public interface IVehicleServiceAsync
    {
        Task<Guid> AddVehicleAsync(AutoMobile vehicle);
        Task<bool> DeleteVehicleAsync(Guid id);
        Task<AutoMobile?> GetVehicleAsync(Guid id);
        Task<IEnumerable<AutoMobile>> GetVehiclesAsync();
        Task<bool> UpdateVehicleAsync(Guid id, AutoMobile vehicle);
    }
}