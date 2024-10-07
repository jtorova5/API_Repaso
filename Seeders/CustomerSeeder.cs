using Microsoft.EntityFrameworkCore;
using RepasoAPI.Models;

namespace RepasoAPI.Seeders;

public class CustomerSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>().HasData(
            new Customer { Id = 1, UserName = "John", Email = "john.doe@example.com", Password = "123"},
            new Customer { Id = 2, UserName = "Jane", Email = "jane.smith@example.com", Password = "456"}
        );
    }
}
