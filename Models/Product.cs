using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepasoAPI.Models;

[Table("products")]
public class Product(string productName)
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [MaxLength(100)]
    [Column("product_name")]
    public required string ProductName { get; set; } = productName.ToLower().Trim();

    [ForeignKey("categories")]
    [Column("category_id")]
    public int CategoryId { get; set; }
}
