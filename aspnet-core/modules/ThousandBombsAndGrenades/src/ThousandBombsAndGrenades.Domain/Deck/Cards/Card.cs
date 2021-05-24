using System;
using System.Xml.Serialization;

namespace ThousandBombsAndGrenades.Deck.Cards
{
    [XmlInclude(typeof(AnimalsCard))]
    [XmlInclude(typeof(DiamondCard))]
    [XmlInclude(typeof(GoldenCoinCard))]
    [XmlInclude(typeof(PirateCard))]
    [XmlInclude(typeof(PirateShipCard))]
    [XmlInclude(typeof(SkullCard))]
    [XmlInclude(typeof(TresureChestCard))]
    [XmlInclude(typeof(WaiterCard))]
    [Serializable]
    public abstract class Card
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public int Points { get; set; }
    }
}
