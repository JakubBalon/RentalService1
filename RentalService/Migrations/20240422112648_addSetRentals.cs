using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalService.Migrations
{
    /// <inheritdoc />
    public partial class addSetRentals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_AspNetUsers_UserId",
                table: "Equipments");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Equipments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "SetRentals",
                columns: table => new
                {
                    SetRentalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    setName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RentedEquipment1Id = table.Column<int>(type: "int", nullable: false),
                    RentedEquipmentName1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RentedEquipment2Id = table.Column<int>(type: "int", nullable: false),
                    RentedEquipmentName2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RentedEquipment3Id = table.Column<int>(type: "int", nullable: false),
                    RentedEquipmentName3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SetRentalLenght = table.Column<double>(type: "float", nullable: false),
                    SetRentalPrice = table.Column<double>(type: "float", nullable: false),
                    SetRentalStartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SetRentalEndTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SetRentals", x => x.SetRentalId);
                    table.ForeignKey(
                        name: "FK_SetRentals_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SetRentals_Equipments_RentedEquipment1Id",
                        column: x => x.RentedEquipment1Id,
                        principalTable: "Equipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SetRentals_Equipments_RentedEquipment2Id",
                        column: x => x.RentedEquipment2Id,
                        principalTable: "Equipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SetRentals_Equipments_RentedEquipment3Id",
                        column: x => x.RentedEquipment3Id,
                        principalTable: "Equipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SetRentals_RentedEquipment1Id",
                table: "SetRentals",
                column: "RentedEquipment1Id");

            migrationBuilder.CreateIndex(
                name: "IX_SetRentals_RentedEquipment2Id",
                table: "SetRentals",
                column: "RentedEquipment2Id");

            migrationBuilder.CreateIndex(
                name: "IX_SetRentals_RentedEquipment3Id",
                table: "SetRentals",
                column: "RentedEquipment3Id");

            migrationBuilder.CreateIndex(
                name: "IX_SetRentals_UserId",
                table: "SetRentals",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_AspNetUsers_UserId",
                table: "Equipments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_AspNetUsers_UserId",
                table: "Equipments");

            migrationBuilder.DropTable(
                name: "SetRentals");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Equipments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_AspNetUsers_UserId",
                table: "Equipments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
