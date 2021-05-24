using System.Collections.Generic;

namespace ThousandBombsAndGrenades.Dice
{
    public class DiceRollDto
    {
        public List<DiceDto> Dice { get; set; }
        public List<DiceDto> Picked { get; set; }
    }
}
