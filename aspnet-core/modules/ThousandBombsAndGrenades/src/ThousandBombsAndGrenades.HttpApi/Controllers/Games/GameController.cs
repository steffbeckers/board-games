using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ThousandBombsAndGrenades.Games;
using ThousandBombsAndGrenades.Players;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
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

        [HttpGet]
        public virtual Task<PagedResultDto<GameDto>> GetListAsync()
        {
            return _gamesAppService.GetListAsync();
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<GameDto> GetAsync(Guid id)
        {
            return _gamesAppService.GetAsync(id);
        }

        [HttpPost]
        public Task<GameDto> CreateAsync()
        {
            return _gamesAppService.CreateAsync();
        }

        [HttpPost]
        [Route("{id}/players")]
        public Task<GameDto> AddPlayerAsync(Guid id, PlayerDto playerDto)
        {
            return _gamesAppService.AddPlayerAsync(id, playerDto);
        }

        [HttpDelete]
        [Route("{id}/players/{playerId}")]
        public Task<GameDto> RemovePlayerAsync(Guid id, Guid playerId)
        {
            return _gamesAppService.RemovePlayerAsync(id, playerId);
        }
    }
}
