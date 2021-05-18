using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;

namespace ThousandBombsAndGrenades.Games
{
    [RemoteService(IsEnabled = false)]
    public class GamesAppService : ApplicationService, IGamesAppService
    {
        private readonly GameManager _gameManager;

        public GamesAppService(GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        public async Task<GameDto> CreateAsync()
        {
            Game game = await _gameManager.CreateAsync();
            return ObjectMapper.Map<Game, GameDto>(game);
        }
    }
}
