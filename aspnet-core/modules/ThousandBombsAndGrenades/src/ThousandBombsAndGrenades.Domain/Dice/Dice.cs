using System;
using System.Collections.Generic;
using ThousandBombsAndGrenades.Dice.Sides;

namespace ThousandBombsAndGrenades.Dice
{
    [Serializable]
    public class Dice
    {
        public DiceSide FacingUp { get; set; }
        private List<DiceSide> Sides { get; set; }

        public Dice()
        {
            Sides = new List<DiceSide>
            {
                new DiamondSide(),
                new GoldenCoinSide(),
                new MonkeySide(),
                new ParrotSide(),
                new SkullSide(),
                new SwordsSide(),
            };
        }

        public void Roll()
        {
            Random rng = new Random();
            FacingUp = Sides[rng.Next(Sides.Count)];
        }
    }
}
