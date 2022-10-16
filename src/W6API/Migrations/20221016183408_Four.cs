using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace W6API.Migrations
{
    public partial class Four : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "71ddb65d-7c09-4598-b7f4-17ff298bf32d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c42b1df3-6bbe-490c-871a-2792568d8761");

            migrationBuilder.RenameColumn(
                name: "geslacht_Identifies",
                table: "AspNetUsers",
                newName: "geslacht_identifies");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "0a5b6b3c-d9dd-42f2-ac56-5d0b7a85d04c", "0bdfa055-d570-499f-8e33-03a4426f3ad8", "Role", "Gast", "GAST" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "41b4892b-bcb8-45b3-915f-194fdd7e0091", "102199fc-9307-4733-b0cf-62b5c776426a", "Role", "Medewerker", "MEDEWERKER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a5b6b3c-d9dd-42f2-ac56-5d0b7a85d04c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41b4892b-bcb8-45b3-915f-194fdd7e0091");

            migrationBuilder.RenameColumn(
                name: "geslacht_identifies",
                table: "AspNetUsers",
                newName: "geslacht_Identifies");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "71ddb65d-7c09-4598-b7f4-17ff298bf32d", "d8a10947-967d-4829-a092-d6bb96b81cd4", "Role", "Medewerker", "MEDEWERKER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "c42b1df3-6bbe-490c-871a-2792568d8761", "fcd5e379-3363-4d1a-b1b3-42d9932e0a59", "Role", "Gast", "GAST" });
        }
    }
}
