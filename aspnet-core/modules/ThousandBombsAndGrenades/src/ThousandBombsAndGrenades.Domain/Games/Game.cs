using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace ThousandBombsAndGrenades.Games
{
    public class Game : FullAuditedAggregateRoot<Guid>
    {
        public virtual DateTime? StartDate { get; set; }

        public virtual DateTime? EndDate { get; set; }

        public Game()
        {
        }

        public Game(Guid id, DateTime? startDate = null, DateTime? endDate = null)
        {
            Id = id;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
