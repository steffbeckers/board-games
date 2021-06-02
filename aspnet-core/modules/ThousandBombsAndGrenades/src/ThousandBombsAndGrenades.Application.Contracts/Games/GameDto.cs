using System;
using System.Collections.Generic;
using ThousandBombsAndGrenades.Players;
using ThousandBombsAndGrenades.PlayerTurns;
using Volo.Abp.Application.Dtos;

namespace ThousandBombsAndGrenades.Games
{
    public class GameDto : FullAuditedEntityDto<Guid>
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public PlayerTurnDto CurrentPlayerTurn { get; set; }

        public List<PlayerDto> Players { get; set; }
        public List<PlayerTurnDto> PlayerTurns { get; set; }
    }
}