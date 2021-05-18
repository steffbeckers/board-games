using Microsoft.EntityFrameworkCore;
using ThousandBombsAndGrenades.Games;
using ThousandBombsAndGrenades.Players;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace ThousandBombsAndGrenades.EntityFrameworkCore
{
    [ConnectionStringName(ThousandBombsAndGrenadesDbProperties.ConnectionStringName)]
    public interface IThousandBombsAndGrenadesDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
        DbSet<Game> Games { get; }
    }
}