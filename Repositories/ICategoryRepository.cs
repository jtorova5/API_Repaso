using RepasoAPI.Models;

namespace RepasoAPI.Repositories;

public interface ICategoryRepository
{
    Task <IEnumerable<Category>> GetCategories();
    Task<Category> GetCategoryById(int id);
    Task Add(Category category);
    Task Update(Category category);
    Task Delete(int id);
}
