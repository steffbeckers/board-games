using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ThousandBombsAndGrenades.Dice
{
    public class DiceRoll
    {
        public ICollection<Dice> Dice { get; set; }
        public ICollection<Dice> Picked { get; set; }

        public DiceRoll()
        {
            Dice = new Collection<Dice>();
            Picked = new Collection<Dice>();
        }

        public List<Dice> RollDice(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Dice dice = new Dice();
                dice.Roll();

                Dice.Add(dice);
            }

            return Dice.ToList();
        }
    }
}
