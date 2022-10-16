using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace W6API.Migrations
{
    public partial class Three : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9bb918ac-7124-469b-8d3e-ebcfabeedf39");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e74a1a8f-aef4-44d0-9301-a0364a3b0112");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "71ddb65d-7c09-4598-b7f4-17ff298bf32d", "d8a10947-967d-4829-a092-d6bb96b81cd4", "Role", "Medewerker", "MEDEWERKER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "c42b1df3-6bbe-490c-871a-2792568d8761", "fcd5e379-3363-4d1a-b1b3-42d9932e0a59", "Role", "Gast", "GAST" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "71ddb65d-7c09-4598-b7f4-17ff298bf32d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c42b1df3-6bbe-490c-871a-2792568d8761");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "9bb918ac-7124-469b-8d3e-ebcfabeedf39", "99507419-de5a-43d0-80f5-55012aae09af", "Role", "Gast", "GAST" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "e74a1a8f-aef4-44d0-9301-a0364a3b0112", "6f247d63-2f75-4984-8d08-5b05505a0633", "Role", "Medewerker", "MEDEWERKER" });
        }
    }
}
