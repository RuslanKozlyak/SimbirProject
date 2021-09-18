using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Simbir.Migrations
{
    public partial class AddVersion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "version",
                table: "person",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "version",
                table: "library_card",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "version",
                table: "genre",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "version",
                table: "book_genre",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "version",
                table: "book",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "version",
                table: "author",
                type: "rowversion",
                rowVersion: true,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "version",
                table: "person");

            migrationBuilder.DropColumn(
                name: "version",
                table: "library_card");

            migrationBuilder.DropColumn(
                name: "version",
                table: "genre");

            migrationBuilder.DropColumn(
                name: "version",
                table: "book_genre");

            migrationBuilder.DropColumn(
                name: "version",
                table: "book");

            migrationBuilder.DropColumn(
                name: "version",
                table: "author");
        }
    }
}
