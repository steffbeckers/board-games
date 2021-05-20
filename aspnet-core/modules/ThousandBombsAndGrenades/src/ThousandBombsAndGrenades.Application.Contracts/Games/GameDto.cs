using System;
using System.Collections.Generic;
using ThousandBombsAndGrenades.PlayerTurns;
using Volo.Abp.Application.Dtos;

namespace ThousandBombsAndGrenades.Games
{
    public class GameDto : FullAuditedEntityDto<Guid>
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public List<PlayerTurnDto> PlayerTurns { get; set; }
    }
}