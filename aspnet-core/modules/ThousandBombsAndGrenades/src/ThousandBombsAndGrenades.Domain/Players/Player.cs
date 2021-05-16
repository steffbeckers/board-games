using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace ThousandBombsAndGrenades.Players
{
    public class Player : FullAuditedAggregateRoot<Guid>
    {
        public virtual string Name { get; set; }

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
