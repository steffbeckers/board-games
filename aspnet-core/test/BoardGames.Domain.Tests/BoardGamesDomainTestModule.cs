using BoardGames.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace BoardGames
{
    [DependsOn(
        typeof(BoardGamesEntityFrameworkCoreTestModule)
        )]
    public class BoardGamesDomainTestModule : AbpModule
    {

    }
}