using Microsoft.EntityFrameworkCore.Migrations;

namespace Trash_Collector.Migrations
{
    public partial class Initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "479e6cec-4a9c-4855-b57e-0e46b9aa1a1d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a0318a2d-7b15-49b4-98e4-9c62873b9f5b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7c11c24a-96f5-4425-a7b9-9456367293cf", "a5f2c5eb-3f1d-4141-b564-a0990f0da398", "Empoyee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9b10f11e-0de3-4970-ab71-1a735c915110", "180adfd4-5cb5-4f2f-982d-38cc19b2023a", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7c11c24a-96f5-4425-a7b9-9456367293cf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b10f11e-0de3-4970-ab71-1a735c915110");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "479e6cec-4a9c-4855-b57e-0e46b9aa1a1d", "dd530497-96ab-476f-b413-78d1a2d3861b", "Empoyee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a0318a2d-7b15-49b4-98e4-9c62873b9f5b", "a72c6c76-48ba-4865-bced-d4da9a5c7a1c", "Customer", "CUSTOMER" });
        }
    }
}
