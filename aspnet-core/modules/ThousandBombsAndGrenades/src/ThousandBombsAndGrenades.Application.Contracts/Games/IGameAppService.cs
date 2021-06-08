using Microsoft.AspNetCore.Authorization;
using System;
using System.Threading.Tasks;
using ThousandBombsAndGrenades.Players;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ThousandBombsAndGrenades.Games
{
    public interface IGameAppService : IApplicationService
    {
        Task<PagedResultDto<GameDto>> GetListAsync();
        Task<GameDto> GetAsync(Guid id);
        Task<GameDto> CreateAsync();
        Task<GameDto> JoinAsync(Guid id);
        Task<GameDto> LeaveAsync(Guid id);
        Task<GameDto> KickPlayerAsync(Guid id, Guid playerId);
        Task<GameDto> StartAsync(Guid id);
        Task<GameDto> DrawCardAsync(Guid id);
        Task<GameDto> RollDiceAsync(Guid id);
        Task<GameDto> PickDiceAsync(Guid id, int index);
        Task<GameDto> ReturnDiceAsync(Guid id, int index);
        Task<GameDto> EndTurnAsync(Guid id);
        Task<GameDto> EndAsync(Guid id);
    }
}
