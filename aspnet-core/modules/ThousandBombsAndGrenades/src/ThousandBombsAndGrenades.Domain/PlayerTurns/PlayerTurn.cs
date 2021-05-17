using System;
using System.Collections.Generic;
using System.Linq;
using ThousandBombsAndGrenades.Deck.Cards;
using ThousandBombsAndGrenades.Dice;
using ThousandBombsAndGrenades.Games;
using Volo.Abp.Domain.Entities.Auditing;

namespace ThousandBombsAndGrenades.PlayerTurns
{
    public class PlayerTurn : AuditedEntity<Guid>
    {
        public PlayerTurn(Game game)
        {
            Game = game;
            GameId = Game.Id;

            DiceRolls = new List<DiceRoll>();
            PickedDice = new List<Dice.Dice>();
        }

        public Game Game { get; }
        public Guid GameId { get; private set; }
        public Guid PlayerId { get; set; }
        public Card Card { get; private set; }
        public List<DiceRoll> DiceRolls { get; private set; }
        public List<Dice.Dice> PickedDice { get; private set; }
        public int Points { get; private set; }

        public void DrawCard()
        {
            Card = Game.DeckOfCards.DrawCard();
        }

        public void RollDice()
        {
            DiceRoll diceRoll = new DiceRoll();
            diceRoll.RollDice(GameConsts.DiceCount - PickedDice.Count);
            DiceRolls.Add(diceRoll);
        }

        public void PickDice(int index)
        {
            DiceRoll diceRoll = DiceRolls.LastOrDefault();
            if (diceRoll == null) return;

            Dice.Dice dice = diceRoll.Dice[index];
            if (dice == null) return;

            PickedDice.Add(dice);

        }

        public void End()
        {
            // TODO: Calculate points

            Game.PlayersTurnEnded();
        }
    }
}
