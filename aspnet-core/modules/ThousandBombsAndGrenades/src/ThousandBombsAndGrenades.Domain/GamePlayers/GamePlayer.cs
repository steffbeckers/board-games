using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace ThousandBombsAndGrenades.GamePlayers
{
    public class GamePlayer : FullAuditedEntity<Guid>
    {
        public Guid GameId { get; set; }
        public Guid PlayerId { get; set; }
        public int SortOrder { get; set; }
        public int Points { get; set; }
    }
}
