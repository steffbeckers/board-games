using Xunit;
using Shouldly;
using ThousandBombsAndGrenades.Cards;
using System.Linq;

namespace ThousandBombsAndGrenades.Deck
{
    public class DeckOfCards_Tests : ThousandBombsAndGrenadesDomainTestBase
    {
        [Fact]
        public void Should_Be_Initialized_With_Cards()
        {
            DeckOfCards deckOfCards = new DeckOfCards();

            deckOfCards.Cards.Count.ShouldBe(35);
        }

        [Fact]
        public void Should_Shuffle_Cards()
        {
            DeckOfCards deckOfCards = new DeckOfCards();

            string before = deckOfCards.ToString();
            deckOfCards.Shuffle();
            string after = deckOfCards.ToString();

            before.ShouldNotBe(after);
        }
    }
}
