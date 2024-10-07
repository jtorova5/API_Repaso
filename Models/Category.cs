using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepasoAPI.Models;

[Table("categories")]
public class Category
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [MaxLength(100)]
    [Column("name")]
    public required string Name { get; set; }

    [MaxLength(100)]
    [Column("category_type")]
    public required string CategoryType { get; set; }

    public Category(string name, string categoryType)
    {
        Name = name.ToLower().Trim();
        CategoryType = categoryType.ToLower().Trim();
    }

    public Category()
    {
    }
}
