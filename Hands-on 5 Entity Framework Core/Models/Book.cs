using System.ComponentModel.DataAnnotations;

namespace Hands_on_5_Entity_Framework_Core.Models
{
    public class Book
    {
        public int Id { get; set; }

        [StringLength(225)]
        public required string Title { get; set; }

        [StringLength(1000)]
        public required string Description { get; set; }
        public int AuthorId { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public required Author Author { get; set; }
    }
}
