using Microsoft.EntityFrameworkCore;
using RepasoAPI.Data;
using RepasoAPI.Models;
using RepasoAPI.Repositories;

namespace RepasoAPI.Services;

public class OrderServices(AppDbContext context) : IOrderRepository
{
    protected readonly AppDbContext _context = context;

    public async Task AddOrder(Order order)
    {
        if (order == null)
        {
            throw new ArgumentNullException(nameof(order), "Order cannot be null");
        }

        try
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException dbEx)
        {
            throw new Exception("Failed to add order into the database", dbEx);
        }
        catch (Exception ex)
        {
            throw new Exception("Unexpected error adding the order", ex);
        }
    }

    public async Task DeleteOrder(int id)
    {
        var order = await _context.Orders.FindAsync(id);
        if (order != null)
        {
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Order>> GetAllOrders()
    {
        if (!_context.Orders.Any())
        {
            throw new InvalidOperationException("No orders found in the database");
        }
        return await _context.Orders.ToListAsync();
    }

    public async Task<Order> GetOrderById(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentException("Id must be a positive integer", nameof(id));
        }
        var order = await _context.Orders.FindAsync(id) ?? throw new InvalidOperationException($"No order found with id {id}");
        return order;
    }

    public async Task UpdateOrder(Order order)
    {
        if (order == null)
        {
            throw new ArgumentNullException(nameof(order), "Order cannot be null");
        }

        try
        {
            _context.Entry(order).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException dbEx)
        {
            throw new Exception("Failed to update order in the database", dbEx);
        }
        catch (Exception ex)
        {
            throw new Exception("Unexpected error updating the order", ex);
        }
    }
}
