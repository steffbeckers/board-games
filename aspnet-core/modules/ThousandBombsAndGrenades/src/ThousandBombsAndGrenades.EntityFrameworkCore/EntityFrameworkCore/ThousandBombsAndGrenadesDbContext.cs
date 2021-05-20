using Microsoft.EntityFrameworkCore;
using ThousandBombsAndGrenades.Games;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace ThousandBombsAndGrenades.EntityFrameworkCore
{
    [ConnectionStringName(ThousandBombsAndGrenadesDbProperties.ConnectionStringName)]
    public class ThousandBombsAndGrenadesDbContext : AbpDbContext<ThousandBombsAndGrenadesDbContext>, IThousandBombsAndGrenadesDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */
        public DbSet<Game> Games { get; set; }

        public ThousandBombsAndGrenadesDbContext(DbContextOptions<ThousandBombsAndGrenadesDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureThousandBombsAndGrenades();
        }
    }
}
