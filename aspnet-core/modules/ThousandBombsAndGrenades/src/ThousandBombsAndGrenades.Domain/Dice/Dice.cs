using System;
using System.Collections.Generic;
using ThousandBombsAndGrenades.Dice.Sides;

namespace ThousandBombsAndGrenades.Dice
{
    public class Dice
    {
        public List<DiceSide> Sides { get; private set; }
        public DiceSide FacingUp { get; private set; }

        public Dice()
        {
            Sides = new List<DiceSide>
            {
                new DiamondSide(),
                new GoldenCoinSide(),
                new MonkeySide(),
                new ParrotSide(),
                new SkullSide(),
            };
        }

        public void Roll()
        {
            Random rng = new Random();
            FacingUp = Sides[rng.Next(Sides.Count)];
        }
    }
}
