using Microsoft.Extensions.DependencyInjection;
using ThousandBombsAndGrenades.Games;
using Volo.Abp.Application;
using Volo.Abp.AutoMapper;
using Volo.Abp.Domain.Entities.Events.Distributed;
using Volo.Abp.Modularity;

namespace ThousandBombsAndGrenades
{
    [DependsOn(
        typeof(ThousandBombsAndGrenadesDomainModule),
        typeof(ThousandBombsAndGrenadesApplicationContractsModule),
        typeof(AbpDddApplicationModule),
        typeof(AbpAutoMapperModule)
        )]
    public class ThousandBombsAndGrenadesApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<ThousandBombsAndGrenadesApplicationModule>();

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<ThousandBombsAndGrenadesApplicationModule>(validate: true);
            });

            Configure<AbpDistributedEntityEventOptions>(options =>
            {
                options.AutoEventSelectors.Add<Game>();
                options.EtoMappings.Add<Game, GameEto>();
            });
        }
    }
}
