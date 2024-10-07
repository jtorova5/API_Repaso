using Microsoft.AspNetCore.Mvc;
using RepasoAPI.Models;
using RepasoAPI.Repositories;

namespace RepasoAPI.Controllers.V1.Categories;

[ApiController]
[Route("api/v1/category")]
public class CategoryGetController(ICategoryRepository categoryRepository) : CategoryController(categoryRepository)
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
    {
        var category = await _categoryRepository.GetCategories();
        return Ok(category);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Category>> GetCategoryById(int id)
    {
        var category = await _categoryRepository.GetCategoryById(id);
        if (category == null)
        {
            return NotFound();
        }
        return Ok(category);
    }
}