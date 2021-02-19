using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Data.Migrations
{
    public partial class AddedCustomerEmployeeandPickupmodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "717b6e4f-a5d8-43dd-afcd-99db3609788a");

            migrationBuilder.CreateTable(
                name: "Pickups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PickedUp = table.Column<bool>(nullable: false),
                    Charge = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pickups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    DayOfWeekChosenByCustomer = table.Column<int>(nullable: false),
                    ExtraDay = table.Column<DateTime>(nullable: false),
                    AmountToPay = table.Column<decimal>(nullable: false),
                    StartDateOfSuspension = table.Column<DateTime>(nullable: false),
                    EndDateOfSuspension = table.Column<DateTime>(nullable: false),
                    PickupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Pickups_PickupId",
                        column: x => x.PickupId,
                        principalTable: "Pickups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZipCode = table.Column<int>(nullable: false),
                    DayOfWeekSelectedByEmployee = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1ecd795d-6914-437b-9a67-13c37b3ec048", "f6d8a5c5-d71b-4593-af17-25ad05c82baa", "Admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_PickupId",
                table: "Customers",
                column: "PickupId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CustomerId",
                table: "Employees",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Pickups");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ecd795d-6914-437b-9a67-13c37b3ec048");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "717b6e4f-a5d8-43dd-afcd-99db3609788a", "279a2f94-0ff1-4394-9b42-35d0c9a1472f", "Admin", "ADMIN" });
        }
    }
}
