using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace W6API.Migrations
{
    public partial class three : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttractieGebruiker");

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    AttractieId = table.Column<int>(type: "INTEGER", nullable: false),
                    GebruikerId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => new { x.AttractieId, x.GebruikerId });
                    table.ForeignKey(
                        name: "FK_Likes_Attracties_AttractieId",
                        column: x => x.AttractieId,
                        principalTable: "Attractie",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Likes_Gebruikers_GebruikerId",
                        column: x => x.GebruikerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Likes_GebruikerId",
                table: "Likes",
                column: "GebruikerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.CreateTable(
                name: "AttractieGebruiker",
                columns: table => new
                {
                    AttractieId = table.Column<int>(type: "INTEGER", nullable: false),
                    GebruikerId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttractieGebruiker", x => new { x.AttractieId, x.GebruikerId });
                    table.ForeignKey(
                        name: "FK_AttractieGebruiker_Attracties_AttractieId",
                        column: x => x.AttractieId,
                        principalTable: "Attractie",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AttractieGebruiker_Gebruikers_GebruikerId",
                        column: x => x.GebruikerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttractieGebruiker_GebruikerId",
                table: "AttractieGebruiker",
                column: "GebruikerId");
        }
    }
}
