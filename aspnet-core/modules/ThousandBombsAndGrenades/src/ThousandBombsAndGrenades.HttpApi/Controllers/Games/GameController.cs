using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ThousandBombsAndGrenades.Players;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace ThousandBombsAndGrenades.Games
{
    [RemoteService]
    [Area("app")]
    [ControllerName("Games - 1000 Bombs & Grenades")]
    [Route("api/games/thousand-bombs-and-grenades/games")]
    public class GameController : AbpController, IGameAppService
    {
        private readonly IGameAppService _gamesAppService;

        public GameController(IGameAppService gamesAppService)
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

        [HttpGet]
        [Route("{id}/join")]
        public Task<GameDto> JoinAsync(Guid id)
        {
            return _gamesAppService.JoinAsync(id);
        }

        [HttpPost]
        [Route("{id}/players")]
        public Task<GameDto> AddPlayerAsync(Guid id, AddPlayerDto addPlayerDto)
        {
            return _gamesAppService.AddPlayerAsync(id, addPlayerDto);
        }

        [HttpDelete]
        [Route("{id}/players/{playerId}")]
        public Task<GameDto> RemovePlayerAsync(Guid id, Guid playerId)
        {
            return _gamesAppService.RemovePlayerAsync(id, playerId);
        }

        [HttpGet]
        [Route("{id}/start")]
        public virtual Task<GameDto> StartAsync(Guid id)
        {
            return _gamesAppService.StartAsync(id);
        }

        [HttpGet]
        [Route("{id}/draw-card")]
        public virtual Task<GameDto> DrawCardAsync(Guid id)
        {
            return _gamesAppService.DrawCardAsync(id);
        }

        [HttpGet]
        [Route("{id}/roll-dice")]
        public virtual Task<GameDto> RollDiceAsync(Guid id)
        {
            return _gamesAppService.RollDiceAsync(id);
        }

        [HttpGet]
        [Route("{id}/pick-dice")]
        public virtual Task<GameDto> PickDiceAsync(Guid id, int index)
        {
            return _gamesAppService.PickDiceAsync(id, index);
        }

        [HttpGet]
        [Route("{id}/return-dice")]
        public virtual Task<GameDto> ReturnDiceAsync(Guid id, int index)
        {
            return _gamesAppService.ReturnDiceAsync(id, index);
        }

        [HttpGet]
        [Route("{id}/end-turn")]
        public virtual Task<GameDto> EndTurnAsync(Guid id)
        {
            return _gamesAppService.EndTurnAsync(id);
        }

        [HttpGet]
        [Route("{id}/end")]
        public virtual Task<GameDto> EndAsync(Guid id)
        {
            return _gamesAppService.EndAsync(id);
        }
    }
}
