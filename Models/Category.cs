using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepasoAPI.Models;

[Table("categories")]
public class Category(string name, string categoryType)
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [MaxLength(100)]
    [Column("name")]
    public required string Name { get; set; } = name;

    [MaxLength(100)]
    [Column("category_type")]
    public required string CategoryType { get; set; } = categoryType;
}
