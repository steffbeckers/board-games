using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace BoardGames.EntityFrameworkCore
{
    public static class BoardGamesDbContextModelCreatingExtensions
    {
        public static void ConfigureBoardGames(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(BoardGamesConsts.DbTablePrefix + "YourEntities", BoardGamesConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});
        }
    }
}