namespace Hands_on_5_Entity_Framework_Core.Models
{
    public class Author
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }

        public ICollection<Book> Books { get; set; } = [];

    }
}
