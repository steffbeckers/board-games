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

        public Game(Guid id)
        {
            Id = id;
        }

        public void Start()
        {
            this.StartDate = DateTime.Now;
        }

        public void End()
        {
            this.EndDate = DateTime.Now;
        }
    }
}
