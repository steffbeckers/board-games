using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ThousandBombsAndGrenades.PlayerTurns;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace ThousandBombsAndGrenades.Controllers.PlayerTurns
{
    [RemoteService]
    [Area("app")]
    [ControllerName("Games - 1000 Bombs & Grenades")]
    [Route("api/games/thousand-bombs-and-grenades/player-turns")]
    public class PlayerTurnController : AbpController, IPlayerTurnsAppService
    {
        private readonly IPlayerTurnsAppService _playerTurnsAppService;

        public PlayerTurnController(IPlayerTurnsAppService playerTurnsAppService)
        {
            _playerTurnsAppService = playerTurnsAppService;
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<PlayerTurnDto> GetAsync(Guid id)
        {
            return _playerTurnsAppService.GetAsync(id);
        }

        [HttpGet]
        [Route("{id}/draw-card")]
        public virtual Task<PlayerTurnDto> DrawCardAsync(Guid id)
        {
            return _playerTurnsAppService.DrawCardAsync(id);
        }

        [HttpGet]
        [Route("{id}/roll-dice")]
        public virtual Task<PlayerTurnDto> RollDiceAsync(Guid id)
        {
            return _playerTurnsAppService.RollDiceAsync(id);
        }
    }
}
