using System;
using Volo.Abp.Application.Dtos;

namespace ThousandBombsAndGrenades.Games
{
    public class GameDto : FullAuditedEntityDto<Guid>
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}