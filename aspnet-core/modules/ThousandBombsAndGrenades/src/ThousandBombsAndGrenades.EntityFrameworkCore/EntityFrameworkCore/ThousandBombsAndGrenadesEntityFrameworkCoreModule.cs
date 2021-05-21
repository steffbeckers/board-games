using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ThousandBombsAndGrenades.Games;
using ThousandBombsAndGrenades.PlayerTurns;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.DependencyInjection;
using Volo.Abp.Modularity;

namespace ThousandBombsAndGrenades.EntityFrameworkCore
{
    [DependsOn(
        typeof(ThousandBombsAndGrenadesDomainModule),
        typeof(AbpEntityFrameworkCoreModule)
    )]
    public class ThousandBombsAndGrenadesEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<ThousandBombsAndGrenadesDbContext>(options =>
            {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
                options.AddRepository<Game, EfCorePlayerTurnRepository>();
                options.AddRepository<PlayerTurn, EfCorePlayerTurnRepository>();
            });

            Configure<AbpEntityOptions>(options =>
            {
                options.Entity<Game>(gameOptions =>
                {
                    gameOptions.DefaultWithDetailsFunc = query =>
                        query.Include(x => x.Players)
                            .Include(x => x.PlayerTurns);
                });

                options.Entity<PlayerTurn>(playerTurnOptions =>
                {
                    playerTurnOptions.DefaultWithDetailsFunc = query =>
                        query.Include(x => x.Game)
                            .Include(x => x.Player);
                });
            });
        }
    }
}