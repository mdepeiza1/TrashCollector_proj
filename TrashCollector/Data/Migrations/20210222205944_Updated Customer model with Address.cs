using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Data.Migrations
{
    public partial class UpdatedCustomermodelwithAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0c5cd660-3c5f-4b6a-9c64-d48e4af02998");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4efec222-e7fa-4bd1-a48b-1593b3f2e128");

            migrationBuilder.AddColumn<string>(
                name: "AddressLine",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ZipCode",
                table: "Customers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fb42b9bb-dd3f-45fa-9e7d-525528b73b0f", "98f3bed0-cc4d-47cd-91ae-a59736cb0c2d", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9afcc9fd-585a-44c0-8d92-bc74a4429bee", "5ff04a3d-0c47-4e60-9c3b-5d606db26ec4", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9afcc9fd-585a-44c0-8d92-bc74a4429bee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb42b9bb-dd3f-45fa-9e7d-525528b73b0f");

            migrationBuilder.DropColumn(
                name: "AddressLine",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Customers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4efec222-e7fa-4bd1-a48b-1593b3f2e128", "6c86f16c-d301-4c37-8d3a-c900e95601fa", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0c5cd660-3c5f-4b6a-9c64-d48e4af02998", "2de3d31d-c065-4a30-a3b1-cb92e6b02eaf", "Employee", "EMPLOYEE" });
        }
    }
}
