using System.Threading.Tasks;
using ThousandBombsAndGrenades.Games;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities.Events.Distributed;
using Volo.Abp.EventBus.Distributed;

namespace ThousandBombsAndGrenades.Events.Games
{
    public class GameUpdatedHandler : IDistributedEventHandler<EntityUpdatedEto<GameEto>>, ITransientDependency
    {
        public async Task HandleEventAsync(EntityUpdatedEto<GameEto> eventData)
        {
            // TODO: SignalR call
        }
    }
}
