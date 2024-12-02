using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blogizm.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class add_mig_contactaddress_addcolumndesc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ContactAddresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "ContactAddresses");
        }
    }
}
