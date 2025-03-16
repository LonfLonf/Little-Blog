using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LivingAsIntern.Migrations
{
    /// <inheritdoc />
    public partial class AddTextMarkdownAtribute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "textMarkDown",
                table: "posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "textMarkDown",
                table: "posts");
        }
    }
}
