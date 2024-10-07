using Microsoft.EntityFrameworkCore;
using RepasoAPI.Models;
using RepasoAPI.Seeders;

namespace RepasoAPI.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //Seeders
        CustomerSeeder.Seed(modelBuilder);
    }
}
