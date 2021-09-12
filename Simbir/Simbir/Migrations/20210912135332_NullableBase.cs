using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Simbir.Migrations
{
    public partial class NullableBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "person",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "person",
                newName: "modified_date");

            migrationBuilder.RenameColumn(
                name: "AddedDate",
                table: "person",
                newName: "added_date");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "library_card",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "library_card",
                newName: "modified_date");

            migrationBuilder.RenameColumn(
                name: "AddedDate",
                table: "library_card",
                newName: "added_date");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "genre",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "genre",
                newName: "modified_date");

            migrationBuilder.RenameColumn(
                name: "AddedDate",
                table: "genre",
                newName: "added_date");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "book_genre",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "book_genre",
                newName: "modified_date");

            migrationBuilder.RenameColumn(
                name: "AddedDate",
                table: "book_genre",
                newName: "added_date");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "book",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "book",
                newName: "modified_date");

            migrationBuilder.RenameColumn(
                name: "AddedDate",
                table: "book",
                newName: "added_date");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "author",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "author",
                newName: "modified_date");

            migrationBuilder.RenameColumn(
                name: "AddedDate",
                table: "author",
                newName: "added_date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "modified_date",
                table: "person",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "added_date",
                table: "person",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "modified_date",
                table: "library_card",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "added_date",
                table: "library_card",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "modified_date",
                table: "genre",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "added_date",
                table: "genre",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "modified_date",
                table: "book_genre",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "added_date",
                table: "book_genre",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "modified_date",
                table: "book",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "added_date",
                table: "book",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "modified_date",
                table: "author",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "added_date",
                table: "author",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "person",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "modified_date",
                table: "person",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "added_date",
                table: "person",
                newName: "AddedDate");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "library_card",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "modified_date",
                table: "library_card",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "added_date",
                table: "library_card",
                newName: "AddedDate");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "genre",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "modified_date",
                table: "genre",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "added_date",
                table: "genre",
                newName: "AddedDate");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "book_genre",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "modified_date",
                table: "book_genre",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "added_date",
                table: "book_genre",
                newName: "AddedDate");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "book",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "modified_date",
                table: "book",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "added_date",
                table: "book",
                newName: "AddedDate");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "author",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "modified_date",
                table: "author",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "added_date",
                table: "author",
                newName: "AddedDate");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "person",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedDate",
                table: "person",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "library_card",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedDate",
                table: "library_card",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "genre",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedDate",
                table: "genre",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "book_genre",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedDate",
                table: "book_genre",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "book",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedDate",
                table: "book",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "author",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedDate",
                table: "author",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
