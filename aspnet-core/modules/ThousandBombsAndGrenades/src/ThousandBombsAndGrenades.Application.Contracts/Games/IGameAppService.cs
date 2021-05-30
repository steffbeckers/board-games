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
        Task<GameDto> AddPlayerAsync(Guid id, PlayerDto playerDto);
        Task<GameDto> RemovePlayerAsync(Guid id, Guid playerId);
        Task<GameDto> StartAsync(Guid id);
        Task<GameDto> EndAsync(Guid id);
    }
}
