using System;

namespace ThousandBombsAndGrenades.Dice.Sides
{
    [Serializable]
    public class DiamondSide : DiceSide
    {
        public DiamondSide()
        {
            Name = "Diamond";
            Points = 100;
        }
    }
}