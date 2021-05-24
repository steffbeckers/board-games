﻿using System;
using System.Collections.Generic;

namespace ThousandBombsAndGrenades.Dice
{
    [Serializable]
    public class DiceRoll
    {
        public List<Dice> Dice { get; set; }
        public List<Dice> Picked { get; set; }

        public DiceRoll()
        {
            Dice = new List<Dice>();
            Picked = new List<Dice>();
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
