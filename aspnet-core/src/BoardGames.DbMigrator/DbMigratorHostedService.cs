using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BoardGames.Data;
using Serilog;
using Volo.Abp;
using Microsoft.Extensions.Configuration;
using System;

namespace BoardGames.DbMigrator
{
    public class DbMigratorHostedService : IHostedService
    {
        private readonly IHostApplicationLifetime _hostApplicationLifetime;

        public DbMigratorHostedService(IHostApplicationLifetime hostApplicationLifetime)
        {
            _hostApplicationLifetime = hostApplicationLifetime;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using (var application = AbpApplicationFactory.Create<BoardGamesDbMigratorModule>(options =>
            {
                options.UseAutofac();
                options.Services.AddLogging(c => c.AddSerilog());

                // To use appsettings.Development.json override
                options.Services.ReplaceConfiguration(BuildConfiguration());
            }))
            {
                application.Initialize();

                await application
                    .ServiceProvider
                    .GetRequiredService<BoardGamesDbMigrationService>()
                    .MigrateAsync();

                application.Shutdown();

                _hostApplicationLifetime.StopApplication();
            }
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;

        // To use appsettings.Development.json override
        private static IConfiguration BuildConfiguration()
        {
            string environmentName = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT");
            return new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environmentName}.json", true)
                .Build();
        }
    }
}
