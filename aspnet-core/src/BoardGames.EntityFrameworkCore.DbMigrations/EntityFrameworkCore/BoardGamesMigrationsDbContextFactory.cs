using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace BoardGames.EntityFrameworkCore
{
    /* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */
    public class BoardGamesMigrationsDbContextFactory : IDesignTimeDbContextFactory<BoardGamesMigrationsDbContext>
    {
        public BoardGamesMigrationsDbContext CreateDbContext(string[] args)
        {
            BoardGamesEfCoreEntityExtensionMappings.Configure();

            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<BoardGamesMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Default"));

            return new BoardGamesMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../BoardGames.DbMigrator/"))
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
