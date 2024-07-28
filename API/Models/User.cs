using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class User
    {
        public int Id { get; set; }

        [MaxLength(255), MinLength(3), Required]
        public required string UserName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email")]
        public required string Email { get; set; }
    }
}
