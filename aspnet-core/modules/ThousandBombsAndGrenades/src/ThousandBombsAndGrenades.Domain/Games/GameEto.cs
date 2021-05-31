using AutoMapper;
using System;
using Volo.Abp.Domain.Entities.Events.Distributed;

namespace ThousandBombsAndGrenades.Games
{
    [AutoMap(typeof(Game))]
    public class GameEto : EntityEto
    {
        public Guid Id { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
