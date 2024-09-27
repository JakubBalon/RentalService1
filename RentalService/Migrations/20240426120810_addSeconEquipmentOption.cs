using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalService.Migrations
{
    /// <inheritdoc />
    public partial class addSeconEquipmentOption : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RentedEquipment2Id",
                table: "Rentals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RentedEquipment2Name",
                table: "Rentals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_RentedEquipment2Id",
                table: "Rentals",
                column: "RentedEquipment2Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Equipments_RentedEquipment2Id",
                table: "Rentals",
                column: "RentedEquipment2Id",
                principalTable: "Equipments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Equipments_RentedEquipment2Id",
                table: "Rentals");

            migrationBuilder.DropIndex(
                name: "IX_Rentals_RentedEquipment2Id",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "RentedEquipment2Id",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "RentedEquipment2Name",
                table: "Rentals");
        }
    }
}
