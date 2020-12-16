using Microsoft.EntityFrameworkCore.Migrations;

namespace Trash_Collector.Data.Migrations
{
    public partial class Properties_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22911421-6f92-422b-b2bd-eaf8207a3347");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "62f76c20-ac84-4366-ad71-ab9ce6e72e26");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "80bc4ef3-8818-49a0-b2c3-13b66cc46e7b", "60282cf4-c0a0-47c4-a769-2ac1d8adb666", "Empoyee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c1e38524-5f42-46a2-8334-fe1da2bd3a15", "16d80b50-a44a-4939-b3bb-45b6a3bb8083", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "80bc4ef3-8818-49a0-b2c3-13b66cc46e7b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1e38524-5f42-46a2-8334-fe1da2bd3a15");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "22911421-6f92-422b-b2bd-eaf8207a3347", "f069a912-b452-4811-86bf-d514179ec237", "Empoyee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "62f76c20-ac84-4366-ad71-ab9ce6e72e26", "80ae8398-b62e-4894-af97-d31e6570c8bb", "Customer", "CUSTOMER" });
        }
    }
}
