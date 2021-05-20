using System;

namespace ThousandBombsAndGrenades.Deck.Cards
{
    [Serializable]
    public class DiamondCard : Card
    {
        public DiamondCard()
        {
            Name = "Diamond";
            Points = 100;
        }
    }
}
