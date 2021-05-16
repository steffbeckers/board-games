using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace ThousandBombsAndGrenades
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(ThousandBombsAndGrenadesDomainSharedModule)
    )]
    public class ThousandBombsAndGrenadesDomainModule : AbpModule
    {

    }
}
