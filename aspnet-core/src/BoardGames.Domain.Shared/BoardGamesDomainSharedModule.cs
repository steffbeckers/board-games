using BoardGames.Localization;
using Volo.Abp.AuditLogging;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.IdentityServer;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;
using ThousandBombsAndGrenades;

namespace BoardGames
{
    [DependsOn(
        typeof(AbpAuditLoggingDomainSharedModule),
        typeof(AbpBackgroundJobsDomainSharedModule),
        typeof(AbpFeatureManagementDomainSharedModule),
        typeof(AbpIdentityDomainSharedModule),
        typeof(AbpIdentityServerDomainSharedModule),
        typeof(AbpPermissionManagementDomainSharedModule),
        typeof(AbpSettingManagementDomainSharedModule),
        typeof(AbpTenantManagementDomainSharedModule)
        )]
    [DependsOn(typeof(ThousandBombsAndGrenadesDomainSharedModule))]
    public class BoardGamesDomainSharedModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            BoardGamesGlobalFeatureConfigurator.Configure();
            BoardGamesModuleExtensionConfigurator.Configure();
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<BoardGamesDomainSharedModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<BoardGamesResource>("en")
                    .AddBaseTypes(typeof(AbpValidationResource))
                    .AddVirtualJson("/Localization/BoardGames");

                options.DefaultResourceType = typeof(BoardGamesResource);
            });

            Configure<AbpExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("BoardGames", typeof(BoardGamesResource));
            });
        }
    }
}
