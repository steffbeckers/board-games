using System;
using System.ComponentModel.DataAnnotations;

namespace ThousandBombsAndGrenades.Players
{
    public class PlayerDto
    {
        public Guid? Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
