using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepasoAPI.Models;

[Table("customers")]
public class Customer
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [MaxLength(100)]
    [Column("name")]
    public required string UserName { get; set; }

    [MaxLength(100)]
    [Column("email")]
    [EmailAddress]
    public required string Email { get; set; }

    [MaxLength(256)]
    [Column("password")]
    public required string Password { get; set; }

    public Customer(string userName, string email, string password)
    {
        UserName = userName.ToLower().Trim();
        Email = email.ToLower().Trim();
        Password = password.ToLower().Trim();
    }
    
    public Customer()
    {
    }
}
