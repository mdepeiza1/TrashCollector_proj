using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Data.Migrations
{
    public partial class AddedadditionalcolumnsinCustomerforfullAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "AddressLine1",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressLine2",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Customers",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "011bcb99-029d-475a-beef-8fa20b5d8818", "78b5aa59-8710-4a8e-9756-20ff70b22ab6", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "afe43d45-c716-4a34-bd96-6fc1aba40073", "4243ac23-2afd-43e4-a66b-aac381ce2f1f", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "011bcb99-029d-475a-beef-8fa20b5d8818");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "afe43d45-c716-4a34-bd96-6fc1aba40073");

            migrationBuilder.DropColumn(
                name: "AddressLine1",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "AddressLine2",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Customers");

            migrationBuilder.AddColumn<string>(
                name: "AddressLine",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fb42b9bb-dd3f-45fa-9e7d-525528b73b0f", "98f3bed0-cc4d-47cd-91ae-a59736cb0c2d", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9afcc9fd-585a-44c0-8d92-bc74a4429bee", "5ff04a3d-0c47-4e60-9c3b-5d606db26ec4", "Employee", "EMPLOYEE" });
        }
    }
}
