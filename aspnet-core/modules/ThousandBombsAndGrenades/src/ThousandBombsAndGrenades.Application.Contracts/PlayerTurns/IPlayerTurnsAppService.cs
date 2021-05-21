using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace ThousandBombsAndGrenades.PlayerTurns
{
    public interface IPlayerTurnsAppService : IApplicationService
    {
        Task<PlayerTurnDto> GetAsync(Guid id);
        Task<PlayerTurnDto> DrawCardAsync(Guid id);
        Task<PlayerTurnDto> RollDiceAsync(Guid id);
    }
}
