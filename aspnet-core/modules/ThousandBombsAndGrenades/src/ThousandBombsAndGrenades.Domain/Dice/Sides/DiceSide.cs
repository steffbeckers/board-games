using System;
using System.Xml.Serialization;

namespace ThousandBombsAndGrenades.Dice.Sides
{
    [XmlInclude(typeof(DiamondSide))]
    [XmlInclude(typeof(GoldenCoinSide))]
    [XmlInclude(typeof(MonkeySide))]
    [XmlInclude(typeof(ParrotSide))]
    [XmlInclude(typeof(SkullSide))]
    [XmlInclude(typeof(SwordsSide))]
    [Serializable]
    public abstract class DiceSide
    {
        public int Points { get; set; }
    }
}