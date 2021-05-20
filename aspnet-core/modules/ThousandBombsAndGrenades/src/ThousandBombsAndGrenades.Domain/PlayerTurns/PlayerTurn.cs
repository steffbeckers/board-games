using System;
using System.Collections.Generic;
using System.Linq;
using ThousandBombsAndGrenades.Deck.Cards;
using ThousandBombsAndGrenades.Dice;
using ThousandBombsAndGrenades.Games;
using ThousandBombsAndGrenades.Players;
using Volo.Abp.Domain.Entities.Auditing;

namespace ThousandBombsAndGrenades.PlayerTurns
{
    public class PlayerTurn : AuditedEntity<Guid>
    {
        public Card Card { get; set; }
        public int Points { get; private set; }

        public Guid GameId { get; set; }
        public Game Game { get; set; }

        public Guid PlayerId { get; set; }
        public Player Player { get; set; }

        public List<DiceRoll> DiceRolls { get; private set; }
        public List<Dice.Dice> PickedDice { get; private set; }

        public PlayerTurn()
        {
            DiceRolls = new List<DiceRoll>();
            PickedDice = new List<Dice.Dice>();
        }

        public void DrawCard()
        {
            Card = Game.DeckOfCards.DrawCard();
        }

        public void RollDice()
        {
            // Validation
            if (Card == null)
            {
                throw new PlayerTurnHasToStartByDrawingACardFirstException();
            }

            DiceRoll diceRoll = new DiceRoll();
            diceRoll.RollDice(GameConsts.DiceCount - PickedDice.Count);
            DiceRolls.Add(diceRoll);
        }

        public void PickDice(int index)
        {
            // Validation
            // TODO: You can't pick a dice if there are no dice rolled

            DiceRoll diceRoll = DiceRolls.LastOrDefault();
            if (diceRoll == null) return;

            Dice.Dice dice = diceRoll.Dice[index];
            if (dice == null) return;

            PickedDice.Add(dice);

            // TODO: Calculate points?
        }

        public void End()
        {
            // TODO: Calculate points?

            Game.PlayersTurnEnded();
        }
    }
}
