using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace BoardGames.Data
{
    /* This is used if database provider does't define
     * IBoardGamesDbSchemaMigrator implementation.
     */
    public class NullBoardGamesDbSchemaMigrator : IBoardGamesDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}