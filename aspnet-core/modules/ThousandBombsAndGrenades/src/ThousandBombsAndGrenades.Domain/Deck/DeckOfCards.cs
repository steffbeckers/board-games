using System;
using System.Collections.Generic;
using System.Linq;
using ThousandBombsAndGrenades.Deck.Cards;

namespace ThousandBombsAndGrenades.Deck
{
    public class DeckOfCards
    {
        public List<Card> Cards { get; private set; }

        public DeckOfCards()
        {
            ShuffleNewDeck();
        }

        public Card DrawCard()
        {
            // Draw the top card
            Card card = Cards.FirstOrDefault();

            // If no card, shuffle a new deck and draw its top card
            if (card == null)
            {
                ShuffleNewDeck();
                card = Cards.First();
            }

            // Remove the card from the deck
            Cards.Remove(card);

            return card;
        }

        private void ShuffleNewDeck()
        {
            Cards = new List<Card> {
                new AnimalsCard(),
                new AnimalsCard(),
                new AnimalsCard(),
                new AnimalsCard(),
                new DiamondCard(),
                new DiamondCard(),
                new DiamondCard(),
                new DiamondCard(),
                new GoldenCoinCard(),
                new GoldenCoinCard(),
                new GoldenCoinCard(),
                new GoldenCoinCard(),
                new PirateCard(),
                new PirateCard(),
                new PirateCard(),
                new PirateCard(),
                new PirateShipCard(2),
                new PirateShipCard(2),
                new PirateShipCard(3),
                new PirateShipCard(3),
                new PirateShipCard(4),
                new PirateShipCard(4),
                new SkullCard(1),
                new SkullCard(1),
                new SkullCard(1),
                new SkullCard(2),
                new SkullCard(2),
                new TresureChestCard(),
                new TresureChestCard(),
                new TresureChestCard(),
                new TresureChestCard(),
                new WaiterCard(),
                new WaiterCard(),
                new WaiterCard(),
                new WaiterCard(),
            };

            Shuffle();
        }

        private void Shuffle()
        {
            Random rng = new Random();

            int n = Cards.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card value = Cards[k];
                Cards[k] = Cards[n];
                Cards[n] = value;
            }
        }
    }
}
