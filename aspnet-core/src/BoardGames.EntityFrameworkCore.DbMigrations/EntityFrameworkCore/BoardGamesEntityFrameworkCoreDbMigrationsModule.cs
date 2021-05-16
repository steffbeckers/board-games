using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace BoardGames.EntityFrameworkCore
{
    [DependsOn(
        typeof(BoardGamesEntityFrameworkCoreModule)
        )]
    public class BoardGamesEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<BoardGamesMigrationsDbContext>();
        }
    }
}
