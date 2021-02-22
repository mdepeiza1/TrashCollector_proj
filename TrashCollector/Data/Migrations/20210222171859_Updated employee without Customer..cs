using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Data.Migrations
{
    public partial class UpdatedemployeewithoutCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Customers_CustomerId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_CustomerId",
                table: "Employees");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "62122961-f88a-4f06-96b4-9656f1c2e8ee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d0a9a96d-cfea-4e6e-aab8-d62249a82514");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Employees");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d5ce111d-e995-4b2d-8afb-b146a9c5c6ae", "3085eb0b-493d-465a-b0a3-57de5ae142bb", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "99d52ca1-33b1-4a48-aa26-761739de4f5b", "772b7255-765e-4c2f-9f87-f84b2433004d", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99d52ca1-33b1-4a48-aa26-761739de4f5b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5ce111d-e995-4b2d-8afb-b146a9c5c6ae");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d0a9a96d-cfea-4e6e-aab8-d62249a82514", "f2d86acd-7ccc-4794-ac3e-fc2481561ac3", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "62122961-f88a-4f06-96b4-9656f1c2e8ee", "4829a900-ad7a-4e03-ba1d-29b40911e0a6", "Employee", "EMPLOYEE" });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CustomerId",
                table: "Employees",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Customers_CustomerId",
                table: "Employees",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
