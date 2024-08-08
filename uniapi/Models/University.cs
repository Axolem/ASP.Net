using Microsoft.EntityFrameworkCore;
using NodaTime;
using NpgsqlTypes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace uniapi.Models
{
    [Index(nameof(Name))]
    public class University
    {
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        [JsonIgnore]
        public NpgsqlTsVector? NameSearchVector { get; set; }

        [Required, MaxLength(5), MinLength(2), Column(name: "short_name")]
        public required string ShortName { get; set; }
        public required string Description { get; set; }
        public required string Website { get; set; }
        public int EstablishedYear { get; set; }

        [Required]
        public required string LogoImage { get; set; }
        public int Rank { get; set; }
        public Instant LastUpdated { get; set; }

        public static async Task<List<University>> All()
        {
            await using DBCtx ctx = new();
            return await ctx.Universities.AsNoTracking().ToListAsync();
        }

        public static async Task<List<Address>> AllWithAddresses()
        {
            await using DBCtx ctx = new();
            return await ctx.Addresses.Include(address => address.University).ToListAsync();
        }
    }
}
