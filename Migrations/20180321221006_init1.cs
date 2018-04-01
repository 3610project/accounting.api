using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Fisher.Bookstore.Api.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "ISBN",
                table: "Books",
                newName: "Isbn");

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "Books",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Bio",
                table: "Authors",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_AuthorId",
                table: "Books",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_AuthorId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_AuthorId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Bio",
                table: "Authors");

            migrationBuilder.RenameColumn(
                name: "Isbn",
                table: "Books",
                newName: "ISBN");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Books",
                nullable: true);
        }
    }
}
