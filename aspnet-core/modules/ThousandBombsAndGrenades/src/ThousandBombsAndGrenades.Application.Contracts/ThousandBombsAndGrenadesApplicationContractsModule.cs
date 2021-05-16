using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace ThousandBombsAndGrenades
{
    [DependsOn(
        typeof(ThousandBombsAndGrenadesDomainSharedModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationModule)
        )]
    public class ThousandBombsAndGrenadesApplicationContractsModule : AbpModule
    {

    }
}
