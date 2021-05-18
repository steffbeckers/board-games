using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThousandBombsAndGrenades.Players;
using ThousandBombsAndGrenades.PlayerTurns;
using Xunit;

namespace ThousandBombsAndGrenades.Games
{
    public class Game_Tests : ThousandBombsAndGrenadesDomainTestBase
    {
        [Fact]
        public async Task ShouldRunGame()
        {
            Game game = new Game(Guid.NewGuid());

            game.AddPlayer("Steff");
            game.AddPlayer("Daisy");

            game.Start();

            PlayerTurn playerTurn = game.PlayerTurns.Last();
            playerTurn.DrawCard();
            playerTurn.RollDice();
            playerTurn.PickDice(0);
            playerTurn.PickDice(1);
            playerTurn.PickDice(5);
            playerTurn.RollDice();
            playerTurn.PickDice(1);
            playerTurn.RollDice();
            playerTurn.End();

            playerTurn = game.PlayerTurns.Last();
            playerTurn.DrawCard();
            playerTurn.RollDice();
            playerTurn.End();

            playerTurn = game.PlayerTurns.Last();
            playerTurn.DrawCard();
            playerTurn.RollDice();
            playerTurn.End();

            playerTurn = game.PlayerTurns.Last();
            playerTurn.DrawCard();
            playerTurn.RollDice();
            playerTurn.End();

            playerTurn = game.PlayerTurns.Last();
            playerTurn.DrawCard();
            playerTurn.RollDice();
            playerTurn.End();

            playerTurn = game.PlayerTurns.Last();
            playerTurn.DrawCard();
            playerTurn.RollDice();
            playerTurn.End();

            game.End();
        }
    }
}
