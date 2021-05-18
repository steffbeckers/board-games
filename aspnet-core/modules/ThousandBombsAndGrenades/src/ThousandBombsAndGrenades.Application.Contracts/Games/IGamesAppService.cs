using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace ThousandBombsAndGrenades.Games
{
    public interface IGamesAppService : IApplicationService
    {
        Task<GameDto> CreateAsync();
    }
}
