using System;
using System.Collections.Generic;
using System.Text;
using ThousandBombsAndGrenades.PlayerTurns;

namespace ThousandBombsAndGrenades.Dice
{
    [Serializable]
    public class DiceRoll
    {
        public List<Dice> Dice { get; private set; }

        public DiceRoll()
        {
            Dice = new List<Dice>();
        }

        public List<Dice> RollDice(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Dice dice = new Dice();
                dice.Roll();
                Dice.Add(dice);
            }

            return Dice;
        }
    }
}
