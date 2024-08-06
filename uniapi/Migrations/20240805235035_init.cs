using Microsoft.EntityFrameworkCore.Migrations;
using NodaTime;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace uniapi.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Universities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    short_name = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Website = table.Column<string>(type: "text", nullable: false),
                    EstablishedYear = table.Column<int>(type: "integer", nullable: false),
                    LogoImage = table.Column<string>(type: "text", nullable: false),
                    Rank = table.Column<int>(type: "integer", nullable: false),
                    LastUpdated = table.Column<Instant>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Universities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Street = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    Province = table.Column<string>(type: "text", nullable: false),
                    PostalCode = table.Column<int>(type: "integer", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: false),
                    UniversityId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Universities_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "Universities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_UniversityId",
                table: "Addresses",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_Universities_Name",
                table: "Universities",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Universities_short_name",
                table: "Universities",
                column: "short_name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Universities");
        }
    }
}
