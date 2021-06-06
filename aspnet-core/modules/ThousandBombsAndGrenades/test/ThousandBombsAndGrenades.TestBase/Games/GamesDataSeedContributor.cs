using System;
using System.Threading.Tasks;
using ThousandBombsAndGrenades.Players;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace ThousandBombsAndGrenades.Games
{
    public class GamesDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IGameRepository _gameRepository;

        public GamesDataSeedContributor(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            Game game1 = new Game(Guid.Parse("313dd332-dcf6-4b84-a17f-e4663515a71a"));
            game1.AddPlayer(new Player(Guid.NewGuid(), "Player 1"));
            game1.AddPlayer(new Player(Guid.NewGuid(), "Player 2"));
            await _gameRepository.InsertAsync(game1);

            Game game2 = new Game(Guid.Parse("486d8353-35b5-41c7-a5f5-07392acb6184"));
            game2.AddPlayer(new Player(Guid.NewGuid(), "Player 1"));
            game2.AddPlayer(new Player(Guid.NewGuid(), "Player 2"));
            game2.AddPlayer(new Player(Guid.NewGuid(), "Player 3"));
            await _gameRepository.InsertAsync(game2);
        }
    }
}
