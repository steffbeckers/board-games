using Volo.Abp.Modularity;

namespace ThousandBombsAndGrenades
{
    [DependsOn(
        typeof(ThousandBombsAndGrenadesApplicationModule),
        typeof(ThousandBombsAndGrenadesDomainTestModule)
        )]
    public class ThousandBombsAndGrenadesApplicationTestModule : AbpModule
    {

    }
}
