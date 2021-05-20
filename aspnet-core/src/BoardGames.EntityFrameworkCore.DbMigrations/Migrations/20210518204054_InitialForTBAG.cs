using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace BoardGames.Migrations
{
    public partial class InitialForTBAG : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ThousandBombsAndGrenadesGames",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeckOfCards = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThousandBombsAndGrenadesGames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ThousandBombsAndGrenadesPlayers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false),
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThousandBombsAndGrenadesPlayers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThousandBombsAndGrenadesPlayers_ThousandBombsAndGrenadesGames_GameId",
                        column: x => x.GameId,
                        principalTable: "ThousandBombsAndGrenadesGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ThousandBombsAndGrenadesPlayerTurns",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Card = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Points = table.Column<int>(type: "int", nullable: false),
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DiceRolls = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PickedDice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThousandBombsAndGrenadesPlayerTurns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThousandBombsAndGrenadesPlayerTurns_ThousandBombsAndGrenadesGames_GameId",
                        column: x => x.GameId,
                        principalTable: "ThousandBombsAndGrenadesGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ThousandBombsAndGrenadesPlayerTurns_ThousandBombsAndGrenadesPlayers_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "ThousandBombsAndGrenadesPlayers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ThousandBombsAndGrenadesPlayers_GameId",
                table: "ThousandBombsAndGrenadesPlayers",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_ThousandBombsAndGrenadesPlayerTurns_GameId",
                table: "ThousandBombsAndGrenadesPlayerTurns",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_ThousandBombsAndGrenadesPlayerTurns_PlayerId",
                table: "ThousandBombsAndGrenadesPlayerTurns",
                column: "PlayerId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ThousandBombsAndGrenadesPlayerTurns");

            migrationBuilder.DropTable(
                name: "ThousandBombsAndGrenadesPlayers");

            migrationBuilder.DropTable(
                name: "ThousandBombsAndGrenadesGames");
        }
    }
}
