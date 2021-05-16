using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace ThousandBombsAndGrenades
{
    [DependsOn(
        typeof(ThousandBombsAndGrenadesApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class ThousandBombsAndGrenadesHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "ThousandBombsAndGrenades";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(ThousandBombsAndGrenadesApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
