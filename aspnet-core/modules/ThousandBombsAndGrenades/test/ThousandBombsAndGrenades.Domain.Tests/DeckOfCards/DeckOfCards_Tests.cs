using Xunit;
using Shouldly;

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
    }
}
