using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Simbir.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "author",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    middle_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    added_date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    modified_date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_author", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "genre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    genre_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    added_date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    modified_date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    middle_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    birth_date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    added_date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    modified_date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "book",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    author_id = table.Column<int>(type: "int", nullable: false),
                    year_of_writing = table.Column<DateTime>(type: "datetime2", nullable: true),
                    added_date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    modified_date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_book", x => x.Id);
                    table.ForeignKey(
                        name: "FK_book_author_author_id",
                        column: x => x.author_id,
                        principalTable: "author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "book_genre",
                columns: table => new
                {
                    BooksId = table.Column<int>(type: "int", nullable: false),
                    GenresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_book_genre", x => new { x.BooksId, x.GenresId });
                    table.ForeignKey(
                        name: "FK_book_genre_book_BooksId",
                        column: x => x.BooksId,
                        principalTable: "book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_book_genre_genre_GenresId",
                        column: x => x.GenresId,
                        principalTable: "genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "library_card",
                columns: table => new
                {
                    BooksId = table.Column<int>(type: "int", nullable: false),
                    HumansId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_library_card", x => new { x.BooksId, x.HumansId });
                    table.ForeignKey(
                        name: "FK_library_card_book_BooksId",
                        column: x => x.BooksId,
                        principalTable: "book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_library_card_person_HumansId",
                        column: x => x.HumansId,
                        principalTable: "person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_book_author_id",
                table: "book",
                column: "author_id");

            migrationBuilder.CreateIndex(
                name: "IX_book_genre_GenresId",
                table: "book_genre",
                column: "GenresId");

            migrationBuilder.CreateIndex(
                name: "IX_library_card_HumansId",
                table: "library_card",
                column: "HumansId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "book_genre");

            migrationBuilder.DropTable(
                name: "library_card");

            migrationBuilder.DropTable(
                name: "genre");

            migrationBuilder.DropTable(
                name: "book");

            migrationBuilder.DropTable(
                name: "person");

            migrationBuilder.DropTable(
                name: "author");
        }
    }
}
