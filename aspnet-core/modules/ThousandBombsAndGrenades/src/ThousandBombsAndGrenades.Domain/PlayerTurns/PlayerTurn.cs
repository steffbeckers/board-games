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
            // - Returning dice from treasure chest card

            DiceRoll diceRoll = DiceRolls.LastOrDefault();
            if (diceRoll == null) return;

            Dice.Dice dice = PickedDice[index];
            if (dice == null) return;

            diceRoll.Dice.Add(dice);
            diceRoll.Picked.Remove(dice);

            PickedDice.Remove(dice);

            Points = CalculatePoints();
        }

        public int CalculateSkullCount()
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

        public int CalculatePoints()
        {
            int points = 0;

            // From card
            if (Card != null)
            {
                points += Card.Points;
            }

            // From dice
            foreach (Dice.Dice dice in PickedDice)
            {
                points += dice.FacingUp.Points;
            }

            // From dice combinations
            Dictionary<string, int> diceSideCount = GetDiceSideCount();
            foreach (string diceSide in diceSideCount.Keys)
            {
                diceSideCount.TryGetValue(diceSide, out int count);

                // Diamond card
                if (Card.GetType() == typeof(DiamondCard) && diceSide == typeof(DiamondSide).ToString())
                {
                    count++;
                }
                // Golden coin card
                else if (Card.GetType() == typeof(GoldenCoinCard) && diceSide == typeof(GoldenCoinSide).ToString())
                {
                    count++;
                }

                // Points based on number of dice combination
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

            // Full treasure chest, when all dice add to points, add 500 points
            if (HasFullTreasureChest())
            {
                points = points + 500;
            }

            // Pirate card, when active calculate all points and double them at the end
            if (Card.GetType() == typeof(PirateCard))
            {
                points = points * 2;
            }

            return points;
        }

        private Dictionary<string, int> GetDiceSideCount()
        {
            Dictionary<string, int> diceSideCount = new Dictionary<string, int>();

            foreach (Dice.Dice dice in PickedDice)
            {
                if (!diceSideCount.ContainsKey(dice.FacingUp.GetType().ToString()))
                {
                    diceSideCount.Add(dice.FacingUp.GetType().ToString(), 0);
                }

                diceSideCount.TryGetValue(dice.FacingUp.GetType().ToString(), out int count);
                count++;
                diceSideCount[dice.FacingUp.GetType().ToString()] = count;
            }

            return diceSideCount;
        }

        private bool HasFullTreasureChest()
        {
            // When not all dice are picked, you can't have a full treasure chest
            if (PickedDice.Count != 8)
            {
                return false;
            }

            Dictionary<string, int> diceSideCount = GetDiceSideCount();
            foreach (string diceSide in diceSideCount.Keys)
            {
                diceSideCount.TryGetValue(diceSide, out int count);

                // If any skulls, you can't have a full treasure chest
                if (diceSide == typeof(SkullSide).ToString())
                {
                    return false;
                }
                else if (diceSide == typeof(SwordsSide).ToString() && count < 3)
                {
                    return false;
                }
                else if (diceSide == typeof(ParrotSide).ToString() && count < 3)
                {
                    return false;
                }
                else if (diceSide == typeof(MonkeySide).ToString() && count < 3)
                {
                    return false;
                }
            }

            return true;
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
    }
}
