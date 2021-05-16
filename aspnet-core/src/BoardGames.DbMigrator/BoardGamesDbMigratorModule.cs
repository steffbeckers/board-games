using BoardGames.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace BoardGames.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(BoardGamesEntityFrameworkCoreDbMigrationsModule),
        typeof(BoardGamesApplicationContractsModule)
        )]
    public class BoardGamesDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
