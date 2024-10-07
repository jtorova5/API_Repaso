using System.ComponentModel.DataAnnotations;

namespace RepasoAPI.DTOs.Requests;

public class CategoryDTO
{
    [Required(ErrorMessage = "Name must be provided")]
    [MaxLength(100, ErrorMessage = "Name must be at most 100 characters")]
    [MinLength(3, ErrorMessage = "Name must be at least 3 characters")] 
    public required string Name { get; set; }

    [Required(ErrorMessage = "Category type must be provided")]
    [MaxLength(50, ErrorMessage = "Category type must be at most 50 characters")]
    [MinLength(3, ErrorMessage = "Category type must be at least 3 characters")] 
    public required string CategoryType { get; set; }
}
