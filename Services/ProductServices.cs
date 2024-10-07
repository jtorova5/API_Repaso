using Microsoft.EntityFrameworkCore;
using RepasoAPI.Data;
using RepasoAPI.Models;
using RepasoAPI.Repositories;

namespace RepasoAPI.Services;

public class ProductServices(AppDbContext context) : IProductRepository
{
    protected readonly AppDbContext _context = context;

    public async Task AddProduct(Product product)
    {
        if (product == null)
        {
            throw new ArgumentNullException(nameof(product), "Product cannot be null");
        }

        try
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException dbEx)
        {
            throw new Exception("Failed to add product into the database", dbEx);
        }
        catch (Exception ex)
        {
            throw new Exception("Unexpected error adding the product", ex);
        }
    }

    public async Task DeleteProduct(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product != null)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Product>> GetAllProducts()
    {
        if (!_context.Products.Any())
        {
            throw new InvalidOperationException("No products found in the database");
        }
        return await _context.Products.ToListAsync();
    }

    public async Task<Product> GetProductById(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentException("Id must be a positive integer", nameof(id));
        }
        var product = await _context.Products.FindAsync(id) ?? throw new InvalidOperationException($"No order found with id {id}");
        return product;
    }

    public async Task UpdateProduct(Product product)
    {
        if (product == null)
        {
            throw new ArgumentNullException(nameof(product), "Product cannot be null");
        }

        try
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException dbEx)
        {
            throw new Exception("Failed to update product in the database", dbEx);
        }
        catch (Exception ex)
        {
            throw new Exception("Unexpected error updating the product", ex);
        }
    }
}
