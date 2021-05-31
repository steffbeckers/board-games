using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace ThousandBombsAndGrenades
{
    [DependsOn(
        typeof(ThousandBombsAndGrenadesHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class ThousandBombsAndGrenadesConsoleApiClientModule : AbpModule
    {

    }
}
