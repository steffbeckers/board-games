using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Sqlite;
using Volo.Abp.Modularity;

namespace ThousandBombsAndGrenades.EntityFrameworkCore
{
    [DependsOn(
        typeof(ThousandBombsAndGrenadesTestBaseModule),
        typeof(ThousandBombsAndGrenadesEntityFrameworkCoreModule),
        typeof(AbpEntityFrameworkCoreSqliteModule)
        )]
    public class ThousandBombsAndGrenadesEntityFrameworkCoreTestModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var sqliteConnection = CreateDatabaseAndGetConnection();

            Configure<AbpDbContextOptions>(options =>
            {
                options.Configure(abpDbContextConfigurationContext =>
                {
                    abpDbContextConfigurationContext.DbContextOptions.UseSqlite(sqliteConnection);
                });
            });
        }
        
        private static SqliteConnection CreateDatabaseAndGetConnection()
        {
            var connection = new SqliteConnection("Data Source=:memory:");
            connection.Open();

            new ThousandBombsAndGrenadesDbContext(
                new DbContextOptionsBuilder<ThousandBombsAndGrenadesDbContext>().UseSqlite(connection).Options
            ).GetService<IRelationalDatabaseCreator>().CreateTables();
            
            return connection;
        }
    }
}
