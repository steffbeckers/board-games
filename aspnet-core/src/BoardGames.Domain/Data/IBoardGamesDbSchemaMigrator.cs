using System.Threading.Tasks;

namespace BoardGames.Data
{
    public interface IBoardGamesDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
