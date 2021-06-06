using System;
using System.Linq;
using ThousandBombsAndGrenades.Players;
using ThousandBombsAndGrenades.PlayerTurns;
using Xunit;

namespace ThousandBombsAndGrenades.Games
{
    public class Game_Tests : ThousandBombsAndGrenadesDomainTestBase
    {
        [Fact]
        public void Should_Be_Able_To_Play()
        {
            Game game = new Game(Guid.NewGuid());

            game.AddPlayer(new Player(Guid.NewGuid(), "Player 1"));
            game.AddPlayer(new Player(Guid.NewGuid(), "Player 2"));

            game.Start();

            PlayerTurn playerTurn = game.PlayerTurns.Last();
            playerTurn.DrawCard();
            playerTurn.RollDice();
            playerTurn.PickDice(0);
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
