using Microsoft.EntityFrameworkCore;
using RepasoAPI.Data;
using RepasoAPI.Models;
using RepasoAPI.Repositories;

namespace RepasoAPI.Services;

public class CustomerServices(AppDbContext context) : ICustomerRepository
{
    private readonly AppDbContext _context = context;

    public async Task AddCustomer(Customer customer)
    {
        if (customer == null)
        {
            throw new ArgumentNullException(nameof(customer), "Category cannot be null");
        }

        try
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException dbEx)
        {
            throw new Exception("Failed to add customer into the database", dbEx);
        }
        catch (Exception ex)
        {
            throw new Exception("Unexpected error adding the customer", ex);
        }
    }

    public async Task DeleteCustomer(int id)
    {
        var customer = await _context.Customers.FindAsync(id);
        if (customer != null)
        {
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Customer>> GetAllCustomers()
    {
        if (!_context.Customers.Any())
        {
            throw new InvalidOperationException("No customers found in the database");
        }
        return await _context.Customers.ToListAsync();
    }

    public async Task<Customer> GetCustomerById(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentException("Id must be a positive integer", nameof(id));
        }
        var customer = await _context.Customers.FindAsync(id) ?? throw new InvalidOperationException($"No customer found with id {id}");
        return customer;
    }

    public async Task UpdateCustomer(Customer customer)
    {
        if (customer == null)
        {
            throw new ArgumentNullException(nameof(customer), "Customer cannot be null");
        }

        try
        {
            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException dbEx)
        {
            throw new Exception("Failed to update customer in the database", dbEx);
        }
        catch (Exception ex)
        {
            throw new Exception("Unexpected error updating the customer", ex);
        }
    }
}
