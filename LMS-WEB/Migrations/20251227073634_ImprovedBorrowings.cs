using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMS_WEB.Migrations
{
    /// <inheritdoc />
    public partial class ImprovedBorrowings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "Borrowings",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "Borrowings");
        }
    }
}
