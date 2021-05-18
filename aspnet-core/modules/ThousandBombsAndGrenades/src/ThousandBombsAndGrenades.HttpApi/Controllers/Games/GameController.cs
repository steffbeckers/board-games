using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ThousandBombsAndGrenades.Games;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace ThousandBombsAndGrenades.Controllers.Games
{
    [RemoteService]
    [Area("app")]
    [ControllerName("Game")]
    [Route("api/thousand-bombs-and-grenades/games")]

    public class GameController : AbpController, IGamesAppService
    {
        private readonly IGamesAppService _gamesAppService;

        public GameController(IGamesAppService gamesAppService)
        {
            _gamesAppService = gamesAppService;
        }

        [HttpPost]
        public Task<GameDto> CreateAsync()
        {
            return _gamesAppService.CreateAsync();
        }
    }
}
