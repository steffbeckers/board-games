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
        // TODO
        //Task<PlayerTurnDto> PickDiceAsync(Guid id, int index);
        //Task<PlayerTurnDto> ReturnDiceAsync(Guid id, int index);
        //Task<PlayerTurnDto> EndAsync(Guid id);
    }
}
