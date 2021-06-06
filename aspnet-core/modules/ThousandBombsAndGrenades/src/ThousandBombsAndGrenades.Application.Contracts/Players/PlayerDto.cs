using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace ThousandBombsAndGrenades.Players
{
    public class PlayerDto : AuditedEntityDto<Guid?>
    {
        [Required]
        public string Name { get; set; }
        public int Points { get; set; }
        public int SortOrder { get; set; }
    }
}
