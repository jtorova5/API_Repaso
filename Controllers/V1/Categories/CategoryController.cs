using Microsoft.AspNetCore.Mvc;
using RepasoAPI.Repositories;

namespace RepasoAPI.Controllers.V1.Categories;

[ApiController]
[Route("api/v1/category")]
public class CategoryController(ICategoryRepository categoryRepository) : ControllerBase
{
    protected readonly ICategoryRepository _categoryRepository = categoryRepository;
}
