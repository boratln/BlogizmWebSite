using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blogizm.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class add_mig_blogcolumn_add : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Categories_CategoryId",
                table: "Blogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Tags_TagId",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_CategoryId",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Blogs");

            migrationBuilder.RenameColumn(
                name: "TagId",
                table: "Blogs",
                newName: "BlogCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Blogs_TagId",
                table: "Blogs",
                newName: "IX_Blogs_BlogCategoryId");

            migrationBuilder.AddColumn<string>(
                name: "BlogImage1",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BlogImage2",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BlogImage3",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CoverImageUrl",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Blogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_BlogCategories_BlogCategoryId",
                table: "Blogs",
                column: "BlogCategoryId",
                principalTable: "BlogCategories",
                principalColumn: "BlogCategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_BlogCategories_BlogCategoryId",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "BlogImage1",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "BlogImage2",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "BlogImage3",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "CoverImageUrl",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Blogs");

            migrationBuilder.RenameColumn(
                name: "BlogCategoryId",
                table: "Blogs",
                newName: "TagId");

            migrationBuilder.RenameIndex(
                name: "IX_Blogs_BlogCategoryId",
                table: "Blogs",
                newName: "IX_Blogs_TagId");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Blogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_CategoryId",
                table: "Blogs",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Categories_CategoryId",
                table: "Blogs",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Tags_TagId",
                table: "Blogs",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "TagId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
