using Microsoft.EntityFrameworkCore;

namespace Hands_on_5_Entity_Framework_Core.Models
{
    public class EFCoreWebDemoContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Autors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            _ = optionsBuilder.UseSqlServer(@"Server=.\AXOLE_PC;Database=EFCoreDemoNEWDB;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");
        }
    }
}
