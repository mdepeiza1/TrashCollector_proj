using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Data.Migrations
{
    public partial class AddedExtraPickedUpbooltoCustomermodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63c2cb57-a830-4280-aca7-9b39ae635eaa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9cd18742-dba9-45ef-89ed-41d68e532c5c");

            migrationBuilder.DropColumn(
                name: "PickedUp",
                table: "Customers");

            migrationBuilder.AddColumn<bool>(
                name: "ExtraPickedUp",
                table: "Customers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "NormalPickedUp",
                table: "Customers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "65c40236-9626-4c2a-9018-4cc3a108d94b", "2f814089-bbb1-40a6-9462-c928238453dd", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4c6fc9af-d845-464d-b80e-cb6836cf3acb", "31aa2121-8b6e-4723-b104-c3ae6773e519", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c6fc9af-d845-464d-b80e-cb6836cf3acb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65c40236-9626-4c2a-9018-4cc3a108d94b");

            migrationBuilder.DropColumn(
                name: "ExtraPickedUp",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "NormalPickedUp",
                table: "Customers");

            migrationBuilder.AddColumn<bool>(
                name: "PickedUp",
                table: "Customers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "63c2cb57-a830-4280-aca7-9b39ae635eaa", "baba3a65-0a6a-4c59-8846-3cec6ab37ae9", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9cd18742-dba9-45ef-89ed-41d68e532c5c", "2f70524e-fa26-4d67-b7d6-3049542b5f9a", "Employee", "EMPLOYEE" });
        }
    }
}
