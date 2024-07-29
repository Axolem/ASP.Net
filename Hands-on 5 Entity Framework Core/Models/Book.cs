namespace Hands_on_5_Entity_Framework_Core.Models
{
    public class Book
    {
        public int Id { get; set; }

        public required string Title { get; set; }
        public required string Description { get; set; }
        public int AuthorId { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public required Author Author { get; set; }
    }
}
