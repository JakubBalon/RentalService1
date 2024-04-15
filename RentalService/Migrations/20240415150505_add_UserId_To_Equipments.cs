using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalService.Migrations
{
    /// <inheritdoc />
    public partial class addUserIdToEquipments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Equipments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_UserId",
                table: "Equipments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_AspNetUsers_UserId",
                table: "Equipments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_AspNetUsers_UserId",
                table: "Equipments");

            migrationBuilder.DropIndex(
                name: "IX_Equipments_UserId",
                table: "Equipments");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Equipments");
        }
    }
}
