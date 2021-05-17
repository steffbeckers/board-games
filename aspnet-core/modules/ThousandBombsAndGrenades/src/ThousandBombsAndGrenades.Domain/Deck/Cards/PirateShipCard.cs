using System;

namespace ThousandBombsAndGrenades.Deck.Cards
{
    public class PirateShipCard : Card
    {
        public int SwordCount { get; private set; }
        public int Points { get; private set; }

        public PirateShipCard(int swordCount)
        {
            switch (swordCount)
            {
                case 2:
                    Points = 300;
                    break;
                case 3:
                    Points = 500;
                    break;
                case 4:
                    Points = 1000;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("swordCount", "Sword count must be 2, 3 or 4");
            }

            SwordCount = swordCount;
        }
    }
}
