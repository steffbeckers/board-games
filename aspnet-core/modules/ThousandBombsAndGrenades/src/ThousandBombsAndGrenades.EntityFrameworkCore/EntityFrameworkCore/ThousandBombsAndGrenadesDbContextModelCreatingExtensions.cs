using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
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
                    v => v.SerializeXML(false),
                    v => v.DeserializeXML<DeckOfCards>()
                );

                b.HasMany(x => x.Players)
                    .WithOne(x => x.Game)
                    .HasForeignKey(x => x.GameId)
                    .OnDelete(DeleteBehavior.Restrict);

                b.HasMany(x => x.PlayerTurns)
                    .WithOne(x => x.Game)
                    .HasForeignKey(x => x.GameId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Player>(b =>
            {
                // Configure table & schema name
                b.ToTable(options.TablePrefix + "Players", options.Schema);

                b.ConfigureByConvention();

                b.Property(x => x.Name)
                    .IsRequired()
                    .HasMaxLength(PlayerConsts.NameMaxLength);

                b.HasOne(x => x.Game)
                    .WithMany(x => x.Players)
                    .HasForeignKey(x => x.GameId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<PlayerTurn>(b =>
            {
                // Configure table & schema name
                b.ToTable(options.TablePrefix + "PlayerTurns", options.Schema);

                b.ConfigureByConvention();

                b.Property(x => x.Card).HasConversion(
                    v => v.SerializeXML(false),
                    v => v.DeserializeXML<Card>()
                );

                b.Property(x => x.DiceRolls).HasConversion(
                    v => v.SerializeXML(false),
                    v => v.DeserializeXML<List<DiceRoll>>()
                );

                b.Property(x => x.PickedDice).HasConversion(
                    v => v.SerializeXML(false),
                    v => v.DeserializeXML<List<Dice.Dice>>()
                );

                b.HasOne(x => x.Game)
                    .WithMany(x => x.PlayerTurns)
                    .HasForeignKey(x => x.GameId)
                    .OnDelete(DeleteBehavior.Restrict);

                b.HasOne(x => x.Player)
                    .WithMany()
                    .HasForeignKey(x => x.PlayerId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }

    public static class XMLExtensions
    {
        public static string SerializeXML<T>(this T value, bool indent = false)
        {
            if (value == null) return string.Empty;

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

            using (StringWriter stringWriter = new StringWriter())
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(stringWriter, new XmlWriterSettings { Indent = indent }))
                {
                    xmlSerializer.Serialize(xmlWriter, value);
                    return stringWriter.ToString();
                }
            }
        }

        public static T DeserializeXML<T>(this string value)
        {
            if (string.IsNullOrEmpty(value)) return default(T);

            using (StringReader stringReader = new StringReader(value))
            {
                return (T)new XmlSerializer(typeof(T)).Deserialize(stringReader);
            }
        }
    }
}
