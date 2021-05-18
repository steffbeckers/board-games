using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;
using ThousandBombsAndGrenades.Deck;
using ThousandBombsAndGrenades.Deck.Cards;
using ThousandBombsAndGrenades.Dice;
using ThousandBombsAndGrenades.Games;
using ThousandBombsAndGrenades.Players;
using ThousandBombsAndGrenades.PlayerTurns;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace ThousandBombsAndGrenades.EntityFrameworkCore
{
    public static class ThousandBombsAndGrenadesDbContextModelCreatingExtensions
    {
        public static void ConfigureThousandBombsAndGrenades(
            this ModelBuilder builder,
            Action<ThousandBombsAndGrenadesModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new ThousandBombsAndGrenadesModelBuilderConfigurationOptions(
                ThousandBombsAndGrenadesDbProperties.DbTablePrefix,
                ThousandBombsAndGrenadesDbProperties.DbSchema
            );

            optionsAction?.Invoke(options);

            /* Configure all entities here. Example:

            builder.Entity<Question>(b =>
            {
                //Configure table & schema name
                b.ToTable(options.TablePrefix + "Questions", options.Schema);
            
                b.ConfigureByConvention();
            
                //Properties
                b.Property(q => q.Title).IsRequired().HasMaxLength(QuestionConsts.MaxTitleLength);
                
                //Relations
                b.HasMany(question => question.Tags).WithOne().HasForeignKey(qt => qt.QuestionId);

                //Indexes
                b.HasIndex(q => q.CreationTime);
            });
            */

            builder.Entity<Game>(b =>
            {
                // Configure table & schema name
                b.ToTable(options.TablePrefix + "Games", options.Schema);

                b.ConfigureByConvention();

                b.Property(x => x.DeckOfCards).HasConversion(
                    v => JsonConvert.SerializeObject(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                    v => JsonConvert.DeserializeObject<DeckOfCards>(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore })
                );
            });

            builder.Entity<Player>(b =>
            {
                // Configure table & schema name
                b.ToTable(options.TablePrefix + "Players", options.Schema);

                b.ConfigureByConvention();

                b.Property(x => x.Name).IsRequired().HasMaxLength(PlayerConsts.NameMaxLength);
            });

            builder.Entity<PlayerTurn>(b =>
            {
                // Configure table & schema name
                b.ToTable(options.TablePrefix + "PlayerTurns", options.Schema);

                b.ConfigureByConvention();

                b.HasOne(x => x.Player).WithOne().OnDelete(DeleteBehavior.NoAction);

                b.Property(x => x.Card).HasConversion(
                    v => JsonConvert.SerializeObject(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                    v => JsonConvert.DeserializeObject<Card>(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore })
                );
                //b.Property(x => x.Card as AnimalsCard).HasJsonConversion();

                b.Property(x => x.DiceRolls).HasJsonConversion();
                b.Property(x => x.PickedDice).HasJsonConversion();
            });
        }
    }

    public static class ValueConversionExtensions
    {
        public static PropertyBuilder<T> HasJsonConversion<T>(this PropertyBuilder<T> propertyBuilder) where T : class, new()
        {
            ValueConverter<T, string> converter = new ValueConverter<T, string>
            (
                v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<T>(v) ?? new T()
            );

            ValueComparer<T> comparer = new ValueComparer<T>
            (
                (l, r) => JsonConvert.SerializeObject(l) == JsonConvert.SerializeObject(r),
                v => v == null ? 0 : JsonConvert.SerializeObject(v).GetHashCode(),
                v => JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(v))
            );

            propertyBuilder.HasConversion(converter);
            propertyBuilder.Metadata.SetValueConverter(converter);
            propertyBuilder.Metadata.SetValueComparer(comparer);
            propertyBuilder.HasColumnType("nvarchar(max)");

            return propertyBuilder;
        }
    }
}
