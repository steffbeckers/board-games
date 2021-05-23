using Microsoft.EntityFrameworkCore.Migrations;

namespace BoardGames.Migrations
{
    public partial class UpdatePlayerTurnTBAG : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ThousandBombsAndGrenadesPlayers_ThousandBombsAndGrenadesGames_GameId",
                table: "ThousandBombsAndGrenadesPlayers");

            migrationBuilder.DropForeignKey(
                name: "FK_ThousandBombsAndGrenadesPlayerTurns_ThousandBombsAndGrenadesGames_GameId",
                table: "ThousandBombsAndGrenadesPlayerTurns");

            migrationBuilder.DropForeignKey(
                name: "FK_ThousandBombsAndGrenadesPlayerTurns_ThousandBombsAndGrenadesPlayers_PlayerId",
                table: "ThousandBombsAndGrenadesPlayerTurns");

            migrationBuilder.DropIndex(
                name: "IX_ThousandBombsAndGrenadesPlayerTurns_PlayerId",
                table: "ThousandBombsAndGrenadesPlayerTurns");

            migrationBuilder.CreateIndex(
                name: "IX_ThousandBombsAndGrenadesPlayerTurns_PlayerId",
                table: "ThousandBombsAndGrenadesPlayerTurns",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ThousandBombsAndGrenadesPlayers_ThousandBombsAndGrenadesGames_GameId",
                table: "ThousandBombsAndGrenadesPlayers",
                column: "GameId",
                principalTable: "ThousandBombsAndGrenadesGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ThousandBombsAndGrenadesPlayerTurns_ThousandBombsAndGrenadesGames_GameId",
                table: "ThousandBombsAndGrenadesPlayerTurns",
                column: "GameId",
                principalTable: "ThousandBombsAndGrenadesGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ThousandBombsAndGrenadesPlayerTurns_ThousandBombsAndGrenadesPlayers_PlayerId",
                table: "ThousandBombsAndGrenadesPlayerTurns",
                column: "PlayerId",
                principalTable: "ThousandBombsAndGrenadesPlayers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ThousandBombsAndGrenadesPlayers_ThousandBombsAndGrenadesGames_GameId",
                table: "ThousandBombsAndGrenadesPlayers");

            migrationBuilder.DropForeignKey(
                name: "FK_ThousandBombsAndGrenadesPlayerTurns_ThousandBombsAndGrenadesGames_GameId",
                table: "ThousandBombsAndGrenadesPlayerTurns");

            migrationBuilder.DropForeignKey(
                name: "FK_ThousandBombsAndGrenadesPlayerTurns_ThousandBombsAndGrenadesPlayers_PlayerId",
                table: "ThousandBombsAndGrenadesPlayerTurns");

            migrationBuilder.DropIndex(
                name: "IX_ThousandBombsAndGrenadesPlayerTurns_PlayerId",
                table: "ThousandBombsAndGrenadesPlayerTurns");

            migrationBuilder.CreateIndex(
                name: "IX_ThousandBombsAndGrenadesPlayerTurns_PlayerId",
                table: "ThousandBombsAndGrenadesPlayerTurns",
                column: "PlayerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ThousandBombsAndGrenadesPlayers_ThousandBombsAndGrenadesGames_GameId",
                table: "ThousandBombsAndGrenadesPlayers",
                column: "GameId",
                principalTable: "ThousandBombsAndGrenadesGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ThousandBombsAndGrenadesPlayerTurns_ThousandBombsAndGrenadesGames_GameId",
                table: "ThousandBombsAndGrenadesPlayerTurns",
                column: "GameId",
                principalTable: "ThousandBombsAndGrenadesGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ThousandBombsAndGrenadesPlayerTurns_ThousandBombsAndGrenadesPlayers_PlayerId",
                table: "ThousandBombsAndGrenadesPlayerTurns",
                column: "PlayerId",
                principalTable: "ThousandBombsAndGrenadesPlayers",
                principalColumn: "Id");
        }
    }
}
