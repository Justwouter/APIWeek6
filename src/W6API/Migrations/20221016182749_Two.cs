using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace W6API.Migrations
{
    public partial class Two : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "70ef594f-b6cf-4697-b066-2fd74bd83c0c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7d4e5a0-ec59-42bf-82a0-7068701ce06e");

            migrationBuilder.AddColumn<string>(
                name: "geslacht_Identifies",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "9bb918ac-7124-469b-8d3e-ebcfabeedf39", "99507419-de5a-43d0-80f5-55012aae09af", "Role", "Gast", "GAST" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "e74a1a8f-aef4-44d0-9301-a0364a3b0112", "6f247d63-2f75-4984-8d08-5b05505a0633", "Role", "Medewerker", "MEDEWERKER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9bb918ac-7124-469b-8d3e-ebcfabeedf39");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e74a1a8f-aef4-44d0-9301-a0364a3b0112");

            migrationBuilder.DropColumn(
                name: "geslacht_Identifies",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "70ef594f-b6cf-4697-b066-2fd74bd83c0c", "dbc7077f-e2b3-4183-8e79-f157c9425ed1", "Role", "Medewerker", "MEDEWERKER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "f7d4e5a0-ec59-42bf-82a0-7068701ce06e", "4622517b-6076-43a1-8dbf-a19952d299f0", "Role", "Gast", "GAST" });
        }
    }
}
