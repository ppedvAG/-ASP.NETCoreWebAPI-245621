using BusinessModel.Contracts;
using BusinessModel.Data;
using BusinessModel.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessModel.Services;

public class OrderService : IOrderServiceAsync
{
    private readonly VehicleDbContext context;

    public OrderService(VehicleDbContext context)
    {
        this.context = context;
    }

    public async Task<IEnumerable<Order>> GetOrdersAsync()
    {
        return await context.Orders.ToListAsync();
    }

    public async Task<Order?> GetOrderAsync(Guid id)
    {
        return await context.Orders.SingleOrDefaultAsync(v => v.Id == id);
    }

    public async Task AddOrderAsync(Order order)
    {
        context.Orders.Add(order);
        await context.SaveChangesAsync();
    }

    public async Task<bool> UpdateOrderAsync(Guid id, Order order)
    {
        if (await context.Orders.AnyAsync(v => v.Id == id))
        {
            context.Orders.Update(order);
            await context.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<bool> DeleteOrderAsync(Guid id)
    {
        var order = await context.Orders.SingleOrDefaultAsync(v => v.Id == id);
        if (order != null)
        {
            context.Orders.Remove(order);
            await context.SaveChangesAsync();
            return true;
        }
        return false;
    }
}
