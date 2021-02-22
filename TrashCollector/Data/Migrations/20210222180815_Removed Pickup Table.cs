using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Data.Migrations
{
    public partial class RemovedPickupTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Pickups_PickupId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_PickupId",
                table: "Customers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99d52ca1-33b1-4a48-aa26-761739de4f5b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5ce111d-e995-4b2d-8afb-b146a9c5c6ae");

            migrationBuilder.DropColumn(
                name: "PickupId",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "Charge",
                table: "Customers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "PickedUp",
                table: "Customers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4efec222-e7fa-4bd1-a48b-1593b3f2e128", "6c86f16c-d301-4c37-8d3a-c900e95601fa", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0c5cd660-3c5f-4b6a-9c64-d48e4af02998", "2de3d31d-c065-4a30-a3b1-cb92e6b02eaf", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0c5cd660-3c5f-4b6a-9c64-d48e4af02998");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4efec222-e7fa-4bd1-a48b-1593b3f2e128");

            migrationBuilder.DropColumn(
                name: "Charge",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PickedUp",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "PickupId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d5ce111d-e995-4b2d-8afb-b146a9c5c6ae", "3085eb0b-493d-465a-b0a3-57de5ae142bb", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "99d52ca1-33b1-4a48-aa26-761739de4f5b", "772b7255-765e-4c2f-9f87-f84b2433004d", "Employee", "EMPLOYEE" });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_PickupId",
                table: "Customers",
                column: "PickupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Pickups_PickupId",
                table: "Customers",
                column: "PickupId",
                principalTable: "Pickups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
