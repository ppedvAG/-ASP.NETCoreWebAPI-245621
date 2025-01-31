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

    public async Task<Guid> AddVehicleAsync(AutoMobile vehicle)
    {
        context.Vehicles.Add(vehicle);
        await context.SaveChangesAsync();
        return vehicle.Id;
    }

    public async Task<bool> UpdateVehicleAsync(Guid id, AutoMobile vehicle)
    {
        var existingVehicle = await context.Vehicles.SingleOrDefaultAsync(v => v.Id == id);
        if (existingVehicle != null)
        {
            // Aktualisiere die Eigenschaften des bestehenden Fahrzeugs
            existingVehicle.Manufacturer = vehicle.Manufacturer;
            existingVehicle.Model = vehicle.Model;
            existingVehicle.Type = vehicle.Type;
            existingVehicle.Fuel = vehicle.Fuel;
            existingVehicle.TopSpeed = vehicle.TopSpeed;
            existingVehicle.Color = vehicle.Color;
            existingVehicle.RegistritationDate = vehicle.RegistritationDate;

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
