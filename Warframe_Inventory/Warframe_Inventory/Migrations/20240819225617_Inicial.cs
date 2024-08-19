using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Warframe_Inventory.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Warframes",
                columns: table => new
                {
                    WarframeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Blueprints = table.Column<int>(type: "INTEGER", nullable: false),
                    Neuroptics = table.Column<int>(type: "INTEGER", nullable: false),
                    Chassis = table.Column<int>(type: "INTEGER", nullable: false),
                    Systems = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warframes", x => x.WarframeId);
                });

            migrationBuilder.InsertData(
                table: "Warframes",
                columns: new[] { "WarframeId", "Blueprints", "Chassis", "Name", "Neuroptics", "Systems" },
                values: new object[] { 1, 1, 1, "Excalibur", 1, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Warframes");
        }
    }
}
