using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Data.Migrations
{
    public partial class Updatetoremovecustomers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c6fc9af-d845-464d-b80e-cb6836cf3acb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65c40236-9626-4c2a-9018-4cc3a108d94b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1ae6c261-a342-4235-a819-1f0d32cd001c", "0a8b6629-cfb6-4a1d-97dd-c985bea788ba", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2efdce7f-0eb2-424e-a7b7-20c3c0fef6ea", "5610421d-6faf-49e5-80b8-59241d3e6757", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ae6c261-a342-4235-a819-1f0d32cd001c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2efdce7f-0eb2-424e-a7b7-20c3c0fef6ea");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "65c40236-9626-4c2a-9018-4cc3a108d94b", "2f814089-bbb1-40a6-9462-c928238453dd", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4c6fc9af-d845-464d-b80e-cb6836cf3acb", "31aa2121-8b6e-4723-b104-c3ae6773e519", "Employee", "EMPLOYEE" });
        }
    }
}
