using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BoardGames.Data;
using Volo.Abp.DependencyInjection;

namespace BoardGames.EntityFrameworkCore
{
    public class EntityFrameworkCoreBoardGamesDbSchemaMigrator
        : IBoardGamesDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreBoardGamesDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the BoardGamesMigrationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<BoardGamesMigrationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}