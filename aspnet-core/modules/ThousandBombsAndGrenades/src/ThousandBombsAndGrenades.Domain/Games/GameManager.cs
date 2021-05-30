using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace ThousandBombsAndGrenades.Games
{
    public class GameManager : DomainService
    {
        private readonly IGameRepository _gameRepository;

        public GameManager(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        /// <summary>
        /// Creates a new game.
        /// </summary>
        /// <returns>The new game</returns>
        public async Task<Game> CreateAsync()
        {
            // Create a new game
            Game game = new Game(Guid.NewGuid())
            {
                DeckOfCards = new Deck.DeckOfCards()
            };

            // TODO: Add the current user's player ID to the game?
            //newGame.AddPlayer(...);

            game = await _gameRepository.InsertAsync(game, autoSave: true);

            return game;
        }
    }
}
