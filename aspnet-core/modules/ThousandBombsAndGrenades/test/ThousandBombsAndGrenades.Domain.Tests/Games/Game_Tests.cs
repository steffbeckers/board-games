﻿using System;
using System.Linq;
using ThousandBombsAndGrenades.Deck;
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

            game.AddPlayer("Steff");
            game.AddPlayer("Daisy");

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
