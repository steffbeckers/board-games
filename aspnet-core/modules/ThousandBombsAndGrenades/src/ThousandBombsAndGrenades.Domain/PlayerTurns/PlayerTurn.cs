using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ThousandBombsAndGrenades.Cards;
using ThousandBombsAndGrenades.Dice;
using ThousandBombsAndGrenades.Games;
using ThousandBombsAndGrenades.Players;
using Volo.Abp.Domain.Entities.Auditing;

namespace ThousandBombsAndGrenades.PlayerTurns
{
    public class PlayerTurn : AuditedEntity<Guid>
    {
        public int Points { get; private set; }
        public bool SkullIslandActive { get; set; }

        public Card Card { get; set; }

        public DiceRoll LastDiceRoll
        {
            get
            {
                return DiceRolls.LastOrDefault();
            }
        }

        public Guid GameId { get; set; }
        public Game Game { get; set; }

        public Guid PlayerId { get; set; }
        public Player Player { get; set; }

        public ICollection<DiceRoll> DiceRolls { get; private set; }
        public ICollection<Dice.Dice> PickedDice { get; private set; }

        public PlayerTurn(Guid id, Guid gameId)
        {
            Id = id;
            GameId = gameId;
            DiceRolls = new Collection<DiceRoll>();
            PickedDice = new Collection<Dice.Dice>();
        }

        private PlayerTurn() {}

        public void DrawCard()
        {
            Card = Game.DeckOfCards.DrawCard();
            Points = CalculatePoints();
        }

        public void RollDice()
        {
            if (Card == null)
            {
                throw new PlayerTurnHasToStartByDrawingACardFirstException();
            }

            // Dice count to roll
            int diceCountToRoll = GameConsts.DiceCount - PickedDice.Count;

            // You must roll at least 2 dice
            if (diceCountToRoll <= 1)
            {
                return;
            }

            // Add a new dice roll
            DiceRoll diceRoll = new DiceRoll();
            diceRoll.RollDice(diceCountToRoll);
            DiceRolls.Add(diceRoll);

            // Automatically pick skull dice
            int skullDiceRolled = 0;
            foreach (Dice.Dice dice in diceRoll.Dice.ToList())
            {
                if (dice.FacingUp.Name == DiceSideConsts.Skull)
                {
                    List<Dice.Dice> diceRollDice = diceRoll.Dice.ToList();
                    PickDice(diceRollDice.IndexOf(dice));
                    skullDiceRolled++;
                }
            }

            // Skull island
            int skullCount = CalculateSkullCount();
            if (DiceRolls.Count == 1 && skullCount >= 4)
            {
                SkullIslandActive = true;
                Points = CalculatePoints();
            }
            // Still in skull island
            else if (SkullIslandActive && skullDiceRolled > 0)
            {
                Points = CalculatePoints();
            }
            // Skull island finished or dead by skull count
            else if (SkullIslandActive && skullDiceRolled == 0 || skullCount >= 3)
            {
                End();
            }
        }

        public void PickDice(int index)
        {
            if (LastDiceRoll == null) return;

            Dice.Dice dice = LastDiceRoll.Dice.ElementAt(index);
            if (dice == null) return;

            // When skull island is active you can only pick skulls
            if (SkullIslandActive && dice.FacingUp.Name != DiceSideConsts.Skull) return;

            LastDiceRoll.Picked.Add(dice);
            LastDiceRoll.Dice.Remove(dice);

            PickedDice.Add(dice);

            Points = CalculatePoints();
        }

        public void ReturnDice(int index)
        {
            // TODO: Returning dice from treasure chest card

            if (LastDiceRoll == null) return;
            if (LastDiceRoll.Picked.Count == 0) return;

            Dice.Dice dice = LastDiceRoll.Picked.ElementAt(index);
            if (dice == null) return;

            // You can't return Dice of type Skull
            // TODO: When waiter card active, 1 skull can be returned during the player's turn
            if (dice.FacingUp.Name == DiceSideConsts.Skull) return;

            LastDiceRoll.Dice.Add(dice);
            LastDiceRoll.Picked.Remove(dice);

            PickedDice.Remove(PickedDice.Where(x => x.FacingUp.Name == dice.FacingUp.Name).FirstOrDefault());

            Points = CalculatePoints();
        }

        public bool HasEnded()
        {
            return Game.PlayerTurns.Last() != this;
        }

        public int CalculateSkullCount()
        {
            int skullCount = 0;

            // From card
            if (Card.Name == CardConsts.Skull)
            {
                skullCount += Card.Count ?? 0;
            }

            // From dice
            foreach (Dice.Dice dice in PickedDice)
            {
                if (dice.FacingUp.Name == DiceSideConsts.Skull)
                {
                    skullCount += 1;
                }
            }

            return skullCount;
        }

        public int CalculatePoints()
        {
            // When skull island is active we calculate the points to subtract from the other player's points
            if (SkullIslandActive)
            {
                return CalculateSkullIslandPoints();
            }

            // Dead by skull count
            int skullCount = CalculateSkullCount();
            if (skullCount >= 3)
            {
                return 0;
            }

            int points = 0;

            // Pirate ship card
            if (Card.Name == CardConsts.PirateShip)
            {
                int swordsDiceCount = PickedDice.Where(x => x.FacingUp.Name == DiceSideConsts.Swords).Sum(x => 1);
                if (swordsDiceCount < Card.Count)
                {
                    return Card.Points.Value * -1;
                }
                else
                {
                    points += Card.Points.Value;
                }
            }
            else
            {
                // From card
                points += Card.Points.HasValue ? Card.Points.Value : 0;
            }

            // From dice
            foreach (Dice.Dice dice in PickedDice)
            {
                points += dice.FacingUp.Points ?? 0;
            }

            // From dice combinations
            Dictionary<string, int> diceSideCount = GetDiceSideCount();
            foreach (string diceSide in diceSideCount.Keys)
            {
                diceSideCount.TryGetValue(diceSide, out int count);

                // Diamond card
                if (Card.Name == CardConsts.Diamond && diceSide == DiceSideConsts.Diamond)
                {
                    count++;
                }
                // Golden coin card
                else if (Card.Name == CardConsts.GoldenCoin && diceSide == DiceSideConsts.GoldenCoin)
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
            if (Card.Name == CardConsts.Pirate)
            {
                points = points * 2;
            }

            return points;
        }

        private int CalculateSkullIslandPoints()
        {
            int skulls = 0;

            // From card
            if (Card != null && Card.Name == CardConsts.Skull)
            {
                skulls += Card.Count ?? 1;
            }

            // From dice
            foreach (Dice.Dice dice in PickedDice.Where(x => x.FacingUp.Name == DiceSideConsts.Skull))
            {
                skulls += 1;
            }

            // -100 points for all other players
            int points = skulls * -100;

            // Pirate card, when active calculate all points and double them at the end
            if (Card.Name == CardConsts.Pirate)
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
                if (!diceSideCount.ContainsKey(dice.FacingUp.Name))
                {
                    diceSideCount.Add(dice.FacingUp.Name, 0);
                }

                diceSideCount.TryGetValue(dice.FacingUp.Name, out int count);
                count++;
                diceSideCount[dice.FacingUp.Name] = count;
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
                if (diceSide == DiceSideConsts.Skull)
                {
                    return false;
                }
                else if (diceSide == DiceSideConsts.Swords && count < 3)
                {
                    return false;
                }
                else if (diceSide == DiceSideConsts.Parrot && count < 3)
                {
                    return false;
                }
                else if (diceSide == DiceSideConsts.Monkey && count < 3)
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

            // Pick all left over dice, from last roll
            for (int i = 0; i < LastDiceRoll.Dice.Count; i++)
            {
                PickDice(i);
            }

            Points = CalculatePoints();

            Game.PlayersTurnEnded();
        }
    }
}
