using ThousandBombsAndGrenades.Games;
using Volo.Abp.Domain;
using Volo.Abp.Domain.Entities.Events.Distributed;
using Volo.Abp.Modularity;

namespace ThousandBombsAndGrenades
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(ThousandBombsAndGrenadesDomainSharedModule)
    )]
    public class ThousandBombsAndGrenadesDomainModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            base.ConfigureServices(context);

            Configure<AbpDistributedEntityEventOptions>(options =>
            {
                options.AutoEventSelectors.Add<Game>();
                options.EtoMappings.Add<Game, GameEto>();
            });
        }
    }
}
