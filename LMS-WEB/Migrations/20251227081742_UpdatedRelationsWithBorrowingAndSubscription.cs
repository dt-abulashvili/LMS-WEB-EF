using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMS_WEB.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedRelationsWithBorrowingAndSubscription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Borrowings_SubscriptionID",
                table: "Borrowings");

            migrationBuilder.CreateIndex(
                name: "IX_Borrowings_SubscriptionID",
                table: "Borrowings",
                column: "SubscriptionID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Borrowings_SubscriptionID",
                table: "Borrowings");

            migrationBuilder.CreateIndex(
                name: "IX_Borrowings_SubscriptionID",
                table: "Borrowings",
                column: "SubscriptionID",
                unique: true,
                filter: "[SubscriptionID] IS NOT NULL");
        }
    }
}
