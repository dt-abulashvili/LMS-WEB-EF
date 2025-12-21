using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMS_WEB.Migrations
{
    /// <inheritdoc />
    public partial class AddedSoftDeleting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Publishers");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Nationalities");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Cities");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Subscriptions",
                newName: "IsCancelled");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Customers",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Borrowings",
                newName: "IsOver");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Books",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Authors",
                newName: "IsDeleted");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReturnDate",
                table: "Borrowings",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReturnDate",
                table: "Borrowings");

            migrationBuilder.RenameColumn(
                name: "IsCancelled",
                table: "Subscriptions",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Customers",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "IsOver",
                table: "Borrowings",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Books",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Authors",
                newName: "IsActive");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Publishers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Nationalities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Genres",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Countries",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Cities",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
