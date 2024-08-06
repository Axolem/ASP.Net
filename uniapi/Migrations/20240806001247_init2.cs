using Microsoft.EntityFrameworkCore.Migrations;
using NpgsqlTypes;

#nullable disable

namespace uniapi.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<NpgsqlTsVector>(
                name: "NameSearchVector",
                table: "Universities",
                type: "tsvector",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameSearchVector",
                table: "Universities");
        }
    }
}
