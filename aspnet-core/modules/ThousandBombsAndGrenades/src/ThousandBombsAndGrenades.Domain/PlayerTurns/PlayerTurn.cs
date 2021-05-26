using System;
using System.Collections.Generic;
using System.Linq;
using ThousandBombsAndGrenades.Deck.Cards;
using ThousandBombsAndGrenades.Dice;
using ThousandBombsAndGrenades.Dice.Sides;
using ThousandBombsAndGrenades.Games;
using ThousandBombsAndGrenades.Players;
using Volo.Abp.Domain.Entities.Auditing;

namespace ThousandBombsAndGrenades.PlayerTurns
{
    public class PlayerTurn : AuditedEntity<Guid>
    {
        public Card Card { get; set; }
        public int Points { get; private set; }
        public bool SkullIslandActive { get; set; }

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
            Points = CalculatePoints();
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

            // Automatically pick skull dice
            int skullDiceRolled = 0;
            foreach (Dice.Dice dice in diceRoll.Dice.ToList())
            {
                if (dice.FacingUp.GetType() == typeof(SkullSide))
                {
                    PickDice(diceRoll.Dice.IndexOf(dice));
                    skullDiceRolled++;
                }
            }

            // Skull island
            int skullCount = CalculateSkullCount();
            if (DiceRolls.Count == 1 && skullCount >= 4)
            {
                SkullIslandActive = true;
            }
            // Still in skull island
            else if (SkullIslandActive && skullDiceRolled > 0)
            {
            }
            // Dead
            else if (skullCount >= 3)
            {
                End();
            }
        }

        public void PickDice(int index)
        {
            // Validation
            // TODO: You can't pick a dice if there are no dice rolled

            DiceRoll diceRoll = DiceRolls.LastOrDefault();
            if (diceRoll == null) return;

            Dice.Dice dice = diceRoll.Dice[index];
            if (dice == null) return;

            diceRoll.Picked.Add(dice);
            diceRoll.Dice.Remove(dice);

            PickedDice.Add(dice);

            Points = CalculatePoints();
        }

        public void ReturnDice(int index)
        {
            // Validation
            // TODO:
            // - You can't return a dice if none were picked yet
            // - You can't return Dice of type Skull
            // - Returning dice from treasure chest

            DiceRoll diceRoll = DiceRolls.LastOrDefault();
            if (diceRoll == null) return;

            Dice.Dice dice = PickedDice[index];
            if (dice == null) return;

            diceRoll.Dice.Add(dice);
            diceRoll.Picked.Remove(dice);

            PickedDice.Remove(dice);

            Points = CalculatePoints();
        }

        public void End()
        {
            // Validation
            // TODO:
            // - Already ended the turn? Check if is still last player turn of game? or add Ended flag?

            Points = CalculatePoints();
            // TODO: What with skull island points? We need to subtract the other players points.

            Game.PlayersTurnEnded();
        }

        private int CalculateSkullCount()
        {
            int skullCount = 0;

            // From card
            if (Card.GetType() == typeof(SkullCard))
            {
                skullCount += ((SkullCard)Card).Count;
            }

            // From dice
            foreach (Dice.Dice dice in PickedDice)
            {
                if (dice.FacingUp.GetType() == typeof(SkullSide))
                {
                    skullCount += 1;
                }
            }

            return skullCount;
        }

        private int CalculatePoints()
        {
            int points = 0;

            if (Card != null)
            {
                points += Card.Points;
            }

            Dictionary<DiceSide, int> diceSideCount = new Dictionary<DiceSide, int>();
            foreach (Dice.Dice dice in PickedDice)
            {
                points += dice.FacingUp.Points;

                if (!diceSideCount.ContainsKey(dice.FacingUp))
                {
                    diceSideCount.Add(dice.FacingUp, 0);
                }

                diceSideCount.TryGetValue(dice.FacingUp, out int count);
                count++;
                diceSideCount[dice.FacingUp] = count;
            }

            foreach (DiceSide diceSide in diceSideCount.Keys)
            {
                diceSideCount.TryGetValue(diceSide, out int count);
                
                if (Card.GetType() == typeof(DiamondCard) && diceSide.GetType() == typeof(DiamondSide))
                {
                    count++;
                }
                else if (Card.GetType() == typeof(GoldenCoinCard) && diceSide.GetType() == typeof(GoldenCoinSide))
                {
                    count++;
                }

                switch (count)
                {
                    case 3:
                        points += 100;
                        break;
                    case 4:
                        points += 200;
                        break;
                    case 5:
                        points += 500;
                        break;
                    case 6:
                        points += 1000;
                        break;
                    case 7:
                        points += 2000;
                        break;
                    case 8:
                        points += 4000;
                        break;
                }
            }

            // TODO: Full treasure chest, when all dice add to points, add 500 points

            // Pirate card
            if (Card.GetType() == typeof(PirateCard))
            {
                points = points * 2;
            }

            return points;
        }
    }
}
