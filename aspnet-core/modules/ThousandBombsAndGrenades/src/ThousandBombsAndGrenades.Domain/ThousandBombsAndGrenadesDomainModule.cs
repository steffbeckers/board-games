using Microsoft.Extensions.DependencyInjection;
using ThousandBombsAndGrenades.Games;
using Volo.Abp.AutoMapper;
using Volo.Abp.Domain;
using Volo.Abp.Domain.Entities.Events.Distributed;
using Volo.Abp.Modularity;

namespace ThousandBombsAndGrenades
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(ThousandBombsAndGrenadesDomainSharedModule),
        typeof(AbpAutoMapperModule)
    )]
    public class ThousandBombsAndGrenadesDomainModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<ThousandBombsAndGrenadesDomainModule>();

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<ThousandBombsAndGrenadesDomainAutoMapperProfile>(validate: true);
            });

            Configure<AbpDistributedEntityEventOptions>(options =>
            {
                options.EtoMappings.Add<Game, GameEto>(typeof(ThousandBombsAndGrenadesDomainModule));

                options.AutoEventSelectors.Add<Game>();
            });
        }
    }
}
