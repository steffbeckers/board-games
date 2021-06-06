using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BoardGames.Migrations
{
    public partial class PlayerUserIdAddedTBAG : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "ThousandBombsAndGrenadesPlayers",
                type: "uniqueidentifier",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ThousandBombsAndGrenadesPlayers");
        }
    }
}
