using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ThousandBombsAndGrenades.Cards;

namespace ThousandBombsAndGrenades.Deck
{
    public class DeckOfCards
    {
        public ICollection<Card> Cards { get; private set; }
        public int CardsDrawn { get; private set; }

        public DeckOfCards()
        {
            // Initialize deck
            if (Cards != null) return;

            Card animalsCard = new Card()
            {
                Name = CardConsts.Animals
            };

            Card diamondCard = new Card()
            {
                Name = CardConsts.Diamond,
                Points = 100
            };

            Card goldenCoinCard = new Card()
            {
                Name = CardConsts.GoldenCoin,
                DisplayName = "Golden coin",
                Points = 100
            };

            Card pirateCard = new Card()
            {
                Name = CardConsts.Pirate
            };

            Card pirateShip2Card = new Card()
            {
                Name = CardConsts.PirateShip,
                DisplayName = "Pirate ship 2 swords",
                Points = 300,
                Count = 2
            };

            Card pirateShip3Card = new Card()
            {
                Name = CardConsts.PirateShip,
                DisplayName = "Pirate ship 3 swords",
                Points = 500,
                Count = 3
            };

            Card pirateShip4Card = new Card()
            {
                Name = CardConsts.PirateShip,
                DisplayName = "Pirate ship 4 swords",
                Points = 1000,
                Count = 4
            };

            Card skullCard = new Card()
            {
                Name = CardConsts.Skull
            };

            Card skull2Card = new Card()
            {
                Name = CardConsts.Skull,
                DisplayName = "2 Skulls",
                Count = 2
            };

            Card treasureChestCard = new Card()
            {
                Name = CardConsts.TreasureChest,
                DisplayName = "Treasure chest"
            };

            Card waiterCard = new Card()
            {
                Name = CardConsts.Waiter
            };

            Cards = new Collection<Card> {
                // 4 Animals
                animalsCard,
                animalsCard,
                animalsCard,
                animalsCard,
                // 4 Diamonds
                diamondCard,
                diamondCard,
                diamondCard,
                diamondCard,
                // 4 Golden coins
                goldenCoinCard,
                goldenCoinCard,
                goldenCoinCard,
                goldenCoinCard,
                // 4 Pirates
                pirateCard,
                pirateCard,
                pirateCard,
                pirateCard,
                // 2 Pirate ships with 2 swords
                pirateShip2Card,
                pirateShip2Card,
                // 2 Pirate ships with 3 swords
                pirateShip3Card,
                pirateShip3Card,
                // 2 Pirate ships with 4 swords
                pirateShip4Card,
                pirateShip4Card,
                // 3 Skulls
                skullCard,
                skullCard,
                skullCard,
                // 2 Double skulls
                skull2Card,
                skull2Card,
                // 4 Treasure chests
                treasureChestCard,
                treasureChestCard,
                treasureChestCard,
                treasureChestCard,
                // 4 Waiter cards
                waiterCard,
                waiterCard,
                waiterCard,
                waiterCard,
            };

            // When initializing, shuffle the deck
            Shuffle();
        }

        public Card DrawCard()
        {
            // Draw the top card
            Card card = Cards.FirstOrDefault();

            // Move the drawn card to the bottom
            Cards.Remove(card);
            Cards.Add(card);

            // If whole deck is drawn, shuffle again
            CardsDrawn++;
            if (CardsDrawn > Cards.Count)
            {
                Shuffle();
            }

            return card;
        }

        public void Shuffle()
        {
            Random rng = new Random();

            List<Card> cards = Cards.ToList();

            int n = cards.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card value = cards.ElementAt(k);
                cards[k] = cards.ElementAt(n);
                cards[n] = value;
            }

            Cards = cards;
        }

        public override string ToString()
        {
            return Cards.Select(x => x.Name).JoinAsString(";");
        }
    }
}
