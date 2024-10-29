using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blogizm.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addcolumnBlogTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {





















            migrationBuilder.AddColumn<int>(
           name: "AuthorId",
           table: "Blogs",
           type: "int",
           nullable: false,
           defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Authors_AuthorId",
                table: "Blogs",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "AuthorId",
                onDelete: ReferentialAction.Cascade);

        }


    }
}
