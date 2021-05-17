using System;

namespace ThousandBombsAndGrenades.Deck.Cards
{
    public class SkullCard : Card
    {
        public int Count { get; private set; }

        public SkullCard(int count)
        {
            if (count != 1 && count != 2)
            {
                throw new ArgumentOutOfRangeException("count", "Skulls count must be 1 or 2");
            }

            Count = count;
        }
    }
}
