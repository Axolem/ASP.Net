using System.ComponentModel.DataAnnotations;

namespace Hands_on_5_Entity_Framework_Core.Models
{
    public class Author
    {
        public int Id { get; set; }

        [StringLength(50)]
        public required string FirstName { get; set; }

        [StringLength(75)]
        public required string LastName { get; set; }

        public ICollection<Book> Books { get; set; } = [];

    }
}
