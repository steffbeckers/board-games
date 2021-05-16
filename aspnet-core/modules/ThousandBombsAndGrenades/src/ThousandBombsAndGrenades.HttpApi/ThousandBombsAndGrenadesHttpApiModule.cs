﻿using Localization.Resources.AbpUi;
using ThousandBombsAndGrenades.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace ThousandBombsAndGrenades
{
    [DependsOn(
        typeof(ThousandBombsAndGrenadesApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class ThousandBombsAndGrenadesHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(ThousandBombsAndGrenadesHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<ThousandBombsAndGrenadesResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}