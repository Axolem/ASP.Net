using Microsoft.EntityFrameworkCore;

namespace uniapi.Models
{
    public class DBCtx : DbContext
    {
        public  DbSet<University> Universities { get; set; }
        public  DbSet<Address> Addresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _ = optionsBuilder.UseNpgsql(
                    @"Host=monorail.proxy.rlwy.net;Port=34836;Database=railway;Username=postgres;Password=rMbaZfwlhAHMXlQugSfksgTAFrDpqjXL",
                    o => o.UseNodaTime());
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<University>()
                .HasIndex(s => s.Name)
                .IsUnique(); 
            modelBuilder.Entity<University>()
                .HasIndex(s => s.ShortName)
                .IsUnique();
        }
    }
}
