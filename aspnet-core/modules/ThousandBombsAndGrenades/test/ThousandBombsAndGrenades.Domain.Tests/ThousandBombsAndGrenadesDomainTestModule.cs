using ThousandBombsAndGrenades.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace ThousandBombsAndGrenades
{
    /* Domain tests are configured to use the EF Core provider.
     * You can switch to MongoDB, however your domain tests should be
     * database independent anyway.
     */
    [DependsOn(
        typeof(ThousandBombsAndGrenadesEntityFrameworkCoreTestModule)
        )]
    public class ThousandBombsAndGrenadesDomainTestModule : AbpModule
    {
        
    }
}
