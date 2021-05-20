using System;

namespace ThousandBombsAndGrenades.Deck.Cards
{
    [Serializable]
    public class SkullCard : Card
    {
        public override string Name { get; set; } = "Skull";
        public int Count { get; set; }

        public SkullCard()
        {
        }

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
