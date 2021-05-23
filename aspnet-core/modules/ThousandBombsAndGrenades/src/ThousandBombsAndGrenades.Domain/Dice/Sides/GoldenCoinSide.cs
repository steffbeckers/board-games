using System;

namespace ThousandBombsAndGrenades.Dice.Sides
{
    [Serializable]
    public class GoldenCoinSide : DiceSide
    {
        public GoldenCoinSide()
        {
            Name = "Golden coin";
            Points = 100;
        }
    }
}
