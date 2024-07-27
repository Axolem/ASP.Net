using System.ComponentModel.DataAnnotations;

namespace MVCFirstApp.Models
{
    public class HelloWorld
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime Dob { get; set; }

        [Required]
        [Range(0, 100)]
        public decimal Price { get; set; }
    }
}
