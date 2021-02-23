using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Data.Migrations
{
    public partial class Changednullablestringbacktostring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ae18f9f-ffa1-4a7e-9f6d-eda4854f3e11");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a9666c83-81e4-4ffa-b33b-6d55a2182e97");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "63c2cb57-a830-4280-aca7-9b39ae635eaa", "baba3a65-0a6a-4c59-8846-3cec6ab37ae9", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9cd18742-dba9-45ef-89ed-41d68e532c5c", "2f70524e-fa26-4d67-b7d6-3049542b5f9a", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63c2cb57-a830-4280-aca7-9b39ae635eaa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9cd18742-dba9-45ef-89ed-41d68e532c5c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a9666c83-81e4-4ffa-b33b-6d55a2182e97", "35345ee7-d6f3-4286-8fde-2b718ba713fe", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7ae18f9f-ffa1-4a7e-9f6d-eda4854f3e11", "446c6634-834a-4ba1-bff1-a90383561dbf", "Employee", "EMPLOYEE" });
        }
    }
}
