using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using ThousandBombsAndGrenades.Cards;
using ThousandBombsAndGrenades.Deck;
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

                b.Property(x => x.Name)
                    .IsRequired()
                    .HasMaxLength(PlayerConsts.NameMaxLength);
            });

            builder.Entity<PlayerTurn>(b =>
            {
                // Configure table & schema name
                b.ToTable(options.TablePrefix + "PlayerTurns", options.Schema);

                b.ConfigureByConvention();

                b.Property(x => x.Card).HasConversion(
                    v => JsonConvert.SerializeObject(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                    v => JsonConvert.DeserializeObject<Card>(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore })
                );

                b.Property(x => x.DiceRolls).HasConversion(
                    v => JsonConvert.SerializeObject(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                    v => JsonConvert.DeserializeObject<List<DiceRoll>>(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore })
                );

                b.Property(x => x.PickedDice).HasConversion(
                    v => JsonConvert.SerializeObject(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                    v => JsonConvert.DeserializeObject<List<Dice.Dice>>(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore })
                );

                b.HasOne<Player>()
                    .WithMany()
                    .HasForeignKey(x => x.PlayerId)
                    .OnDelete(DeleteBehavior.NoAction);
            });
        }
    }
}
