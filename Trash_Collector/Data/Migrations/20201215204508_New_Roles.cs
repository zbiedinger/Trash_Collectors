using Microsoft.EntityFrameworkCore.Migrations;

namespace Trash_Collector.Data.Migrations
{
    public partial class New_Roles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db5ed394-7c77-4e39-8c6b-2a153ff66cd5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "22911421-6f92-422b-b2bd-eaf8207a3347", "f069a912-b452-4811-86bf-d514179ec237", "Empoyee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "62f76c20-ac84-4366-ad71-ab9ce6e72e26", "80ae8398-b62e-4894-af97-d31e6570c8bb", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "db5ed394-7c77-4e39-8c6b-2a153ff66cd5", "864204f1-5568-40eb-8786-35f913f82032", "Admin", "ADMIN" });
        }
    }
}
