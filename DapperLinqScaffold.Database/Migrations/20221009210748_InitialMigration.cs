using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DapperLinqScaffold.Database.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HeroTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    RaceId = table.Column<int>(type: "integer", nullable: false),
                    Power = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RaceTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceTable", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "HeroTable",
                columns: new[] { "Id", "Name", "Power", "RaceId" },
                values: new object[,]
                {
                    { 1, "Legolas", 80, 1 },
                    { 2, "Elrond", 85, 1 },
                    { 3, "Solid Snake", 75, 2 },
                    { 4, "Cloud", 70, 2 },
                    { 5, "Zack", 80, 2 },
                    { 6, "Obi-Wan Kenobi", 90, 3 },
                    { 7, "Anakin Skywalker", 95, 3 },
                    { 8, "Gandalf", 95, 4 },
                    { 9, "Count Dooku", 100, 5 },
                    { 10, "Darth Maul", 85, 5 }
                });

            migrationBuilder.InsertData(
                table: "RaceTable",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Elf" },
                    { 2, "Human" },
                    { 3, "Jedi" },
                    { 4, "Maiar" },
                    { 5, "Sith" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RaceTable_Name",
                table: "RaceTable",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HeroTable");

            migrationBuilder.DropTable(
                name: "RaceTable");
        }
    }
}
