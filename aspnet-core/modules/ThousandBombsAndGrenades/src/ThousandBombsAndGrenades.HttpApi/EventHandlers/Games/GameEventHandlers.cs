using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using ThousandBombsAndGrenades.Games;
using ThousandBombsAndGrenades.Hubs.Games;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities.Events.Distributed;
using Volo.Abp.EventBus.Distributed;

namespace ThousandBombsAndGrenades.Events.Games
{
    public class GameUpdatedHandler : IDistributedEventHandler<EntityUpdatedEto<GameEto>>, ITransientDependency
    {
        private readonly IGameAppService _gameAppService;
        private readonly IHubContext<GameHub> _hubContext;

        public GameUpdatedHandler(
            IGameAppService gameAppService,
            IHubContext<GameHub> hubContext
        )
        {
            _gameAppService = gameAppService;
            _hubContext = hubContext;
        }

        public async Task HandleEventAsync(EntityUpdatedEto<GameEto> eventData)
        {
            GameDto gameDto = await _gameAppService.GetAsync(eventData.Entity.Id);
            await _hubContext.Clients.Groups(gameDto.Id.ToString().ToUpper()).SendAsync("GameUpdate", gameDto);
        }
    }
}
