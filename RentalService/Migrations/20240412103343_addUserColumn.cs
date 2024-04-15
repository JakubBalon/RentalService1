using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalService.Migrations
{
    /// <inheritdoc />
    public partial class addUserColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Rentals",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_UserId",
                table: "Rentals",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_AspNetUsers_UserId",
                table: "Rentals",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_AspNetUsers_UserId",
                table: "Rentals");

            migrationBuilder.DropIndex(
                name: "IX_Rentals_UserId",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Rentals");
        }
    }
}
