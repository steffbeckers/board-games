using Volo.Abp.Modularity;

namespace BoardGames
{
    [DependsOn(
        typeof(BoardGamesApplicationModule),
        typeof(BoardGamesDomainTestModule)
        )]
    public class BoardGamesApplicationTestModule : AbpModule
    {

    }
}