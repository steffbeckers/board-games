﻿using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Application;
using Volo.Abp.AutoMapper;
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
        }
    }
}
