using System;
using System.Collections.Generic;
using ThousandBombsAndGrenades.Cards;
using ThousandBombsAndGrenades.Dice;
using ThousandBombsAndGrenades.Players;
using Volo.Abp.Application.Dtos;

namespace ThousandBombsAndGrenades.PlayerTurns
{
    public class PlayerTurnDto : AuditedEntityDto<Guid>
    {
        public Guid GameId { get; set; }

        public Guid PlayerId { get; set; }
        public PlayerDto Player { get; set; }

        public CardDto Card { get; set; }

        public DiceRollDto LastDiceRoll { get; set; }
        public List<DiceRollDto> DiceRolls { get; set; }
        public List<DiceDto> PickedDice { get; set; }

        public int Points { get; set; }
        public bool SkullIslandActive { get; set; }
    }
}
