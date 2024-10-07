using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepasoAPI.Models;

[Table("customers")]
public class Customer(string userName, string email, string password)
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [MaxLength(100)]
    [Column("name")]
    public required string UserName { get; set; } = userName.ToLower().Trim();

    [MaxLength(100)]
    [Column("email")]
    [EmailAddress]
    public required string Email { get; set; } = email.ToLower().Trim();

    [MaxLength(256)]
    [Column("password")]
    public required string Password { get; set; } = password.ToLower().Trim();
}
