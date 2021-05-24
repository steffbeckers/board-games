using Microsoft.EntityFrameworkCore.Migrations;

namespace BoardGames.Migrations
{
    public partial class AddedSkullIslandActiveToPlayerTurnTBAG : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "SkullIslandActive",
                table: "ThousandBombsAndGrenadesPlayerTurns",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SkullIslandActive",
                table: "ThousandBombsAndGrenadesPlayerTurns");
        }
    }
}
