using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepasoAPI.Models;

[Table("orders")]
public class Order(int productId, int customerId)
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("order_date")]
    public DateTime OrderDate { get; set; }

    [ForeignKey("products")]
    [Column("product_id")]
    public int ProductId { get; set; } = productId;

    [ForeignKey("customers")]
    [Column("customer_id")]
    public int CustomerId { get; set; } = customerId;
}
