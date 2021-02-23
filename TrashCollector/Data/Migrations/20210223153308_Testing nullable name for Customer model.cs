using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Data.Migrations
{
    public partial class TestingnullablenameforCustomermodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "011bcb99-029d-475a-beef-8fa20b5d8818");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "afe43d45-c716-4a34-bd96-6fc1aba40073");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a9666c83-81e4-4ffa-b33b-6d55a2182e97", "35345ee7-d6f3-4286-8fde-2b718ba713fe", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7ae18f9f-ffa1-4a7e-9f6d-eda4854f3e11", "446c6634-834a-4ba1-bff1-a90383561dbf", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "011bcb99-029d-475a-beef-8fa20b5d8818", "78b5aa59-8710-4a8e-9756-20ff70b22ab6", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "afe43d45-c716-4a34-bd96-6fc1aba40073", "4243ac23-2afd-43e4-a66b-aac381ce2f1f", "Employee", "EMPLOYEE" });
        }
    }
}
