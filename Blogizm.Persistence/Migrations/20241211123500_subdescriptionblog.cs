using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blogizm.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class subdescriptionblog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SubDescription",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubDescription",
                table: "Blogs");
        }
    }
}
