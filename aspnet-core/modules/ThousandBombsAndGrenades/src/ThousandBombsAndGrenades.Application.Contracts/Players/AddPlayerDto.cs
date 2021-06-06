using System.ComponentModel.DataAnnotations;

namespace ThousandBombsAndGrenades.Players
{
    public class AddPlayerDto
    {
        [Required]
        public string Name { get; set; }
    }
}
