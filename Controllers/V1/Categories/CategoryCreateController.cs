// using Microsoft.AspNetCore.Mvc;
// using RepasoAPI.Data;
// using RepasoAPI.DTOs.Requests;
// using RepasoAPI.Models;
// using RepasoAPI.Repositories;
// using RepasoAPI.Services;

// namespace RepasoAPI.Controllers.V1.Categories;

// [ApiController]
// [Route("api/v1/category")]
// public class CategoryCreateController(ICategoryRepository categoryRepository) : CategoryController(categoryRepository)
// {
//     [HttpPost]
    // public async Task<ActionResult<Category>> Create(CategoryDTO categoryDTO)
    // {
        // if (!ModelState.IsValid)
        // {
        //     return BadRequest(ModelState);
        // }

        // if (string.IsNullOrEmpty(categoryDTO.Name))
        // {
        //     return BadRequest("Category Name is required.");
        // }

        // var newCategory = new Category(categoryDTO.Name, categoryDTO.CategoryType);

        // await _categoryRepository.Add(newCategory);

        // return Ok(newCategory);
    // }
// }
