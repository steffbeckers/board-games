using System;
using System.Threading.Tasks;
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
            game1.AddPlayer("Steff");
            game1.AddPlayer("Daisy");
            await _gameRepository.InsertAsync(game1);

            Game game2 = new Game(Guid.Parse("486d8353-35b5-41c7-a5f5-07392acb6184"));
            game2.AddPlayer("Daisy");
            game2.AddPlayer("Steff");
            game2.AddPlayer("John Doe");
            await _gameRepository.InsertAsync(game2);
        }
    }
}
