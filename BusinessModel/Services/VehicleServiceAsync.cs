using BusinessModel.Contracts;
using BusinessModel.Data;
using BusinessModel.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessModel.Services;

public class VehicleServiceAsync : IVehicleServiceAsync
{
    private readonly VehicleDbContext context;

    public VehicleServiceAsync(VehicleDbContext context)
    {
        this.context = context;
    }

    public async Task<IEnumerable<AutoMobile>> GetVehiclesAsync()
    {
        return await context.Vehicles.ToListAsync();
    }

    public async Task<AutoMobile?> GetVehicleAsync(Guid id)
    {
        return await context.Vehicles.SingleOrDefaultAsync(v => v.Id == id);
    }

    public async Task AddVehicleAsync(AutoMobile vehicle)
    {
        context.Vehicles.Add(vehicle);
        await context.SaveChangesAsync();
    }

    public async Task<bool> UpdateVehicleAsync(Guid id, AutoMobile vehicle)
    {
        if (await context.Vehicles.AnyAsync(v => v.Id == id))
        {
            context.Vehicles.Update(vehicle);
            await context.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<bool> DeleteVehicleAsync(Guid id)
    {
        var vehicle = await context.Vehicles.SingleOrDefaultAsync(v => v.Id == id);
        if (vehicle != null)
        {
            context.Vehicles.Remove(vehicle);
            await context.SaveChangesAsync();
            return true;
        }
        return false;
    }
}
