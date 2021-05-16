using System;
using System.Collections.Generic;
using System.Text;
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
            // TODO: Check for existing running game for current user
            
            // Create a new game
            Game newGame = new Game(GuidGenerator.Create());

            // TODO: Add the current user's player ID to the game?
            //newGame.AddPlayer(...);

            return newGame;
        }
    }
}
