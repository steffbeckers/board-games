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
        public int Points { get; set; }
        public string Description { get; set; }
    }
}
