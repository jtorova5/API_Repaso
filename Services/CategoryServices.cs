using Microsoft.EntityFrameworkCore;
using RepasoAPI.Data;
using RepasoAPI.Models;
using RepasoAPI.Repositories;

namespace RepasoAPI.Services;

public class CategoryServices(AppDbContext context) : ICategoryRepository
{
    protected readonly AppDbContext _context = context;

    public async Task Add(Category category)
    {
        if (category == null)
        {
            throw new ArgumentNullException(nameof(category), "Category cannot be null");
        }

        try
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException dbEx)
        {
            throw new Exception("Failed to add category into the database", dbEx);
        }
        catch (Exception ex)
        {
            throw new Exception("Unexpected error adding the category", ex);
        }
    }

    public async Task Delete(int id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category != null)
        {
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Category>> GetCategories()
    {
        if (!_context.Categories.Any())
        {
            throw new InvalidOperationException("No categories found in the database");
        }
        return await _context.Categories.ToListAsync();
    }

    public async Task<Category> GetCategoryById(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentException("Id must be a positive integer", nameof(id));
        }
        var category = await _context.Categories.FindAsync(id) ?? throw new InvalidOperationException($"No category found with id {id}");
        return category;
    }

    public async Task Update(Category category)
    {
        if (category == null)
        {
            throw new ArgumentNullException(nameof(category), "Category cannot be null");
        }

        try
        {
            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException dbEx)
        {
            throw new Exception("Failed to update category in the database", dbEx);
        }
        catch (Exception ex)
        {
            throw new Exception("Unexpected error updating the category", ex);
        }
    }
}
