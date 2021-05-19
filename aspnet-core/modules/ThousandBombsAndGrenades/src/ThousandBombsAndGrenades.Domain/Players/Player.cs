using System;
using ThousandBombsAndGrenades.Games;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace ThousandBombsAndGrenades.Players
{
    public class Player : FullAuditedEntity<Guid>
    {
        public string Name { get; private set; }
        public int SortOrder { get; set; }
        public int Points { get; set; }

        public Guid GameId { get; set; }
        public Game Game { get; set; }

        public Player()
        {
        }

        public Player(Guid id, string name)
        {
            Id = id;
            Check.NotNull(name, nameof(name));
            Check.Length(name, nameof(name), PlayerConsts.NameMaxLength, 0);
            Name = name;
        }
    }
}
