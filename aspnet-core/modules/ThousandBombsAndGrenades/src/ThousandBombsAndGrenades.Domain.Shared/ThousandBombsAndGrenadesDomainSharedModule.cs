using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using ThousandBombsAndGrenades.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace ThousandBombsAndGrenades
{
    [DependsOn(
        typeof(AbpValidationModule)
    )]
    public class ThousandBombsAndGrenadesDomainSharedModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<ThousandBombsAndGrenadesDomainSharedModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<ThousandBombsAndGrenadesResource>("en")
                    .AddBaseTypes(typeof(AbpValidationResource))
                    .AddVirtualJson("/Localization/ThousandBombsAndGrenades");
            });

            Configure<AbpExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("ThousandBombsAndGrenades", typeof(ThousandBombsAndGrenadesResource));
            });
        }
    }
}
