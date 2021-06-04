using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ThousandBombsAndGrenades.Dice
{
    public class Dice
    {
        public DiceSide FacingUp { get; set; }
        private ICollection<DiceSide> Sides { get; set; }

        public Dice()
        {
            Sides = new Collection<DiceSide>
            {
                new DiceSide() {
                    Name = DiceSideConsts.Diamond,
                    Points = 100
                },
                new DiceSide() {
                    Name = DiceSideConsts.GoldenCoin,
                    DisplayName = "Golden coin",
                    Points = 100
                },
                new DiceSide() {
                    Name = DiceSideConsts.Monkey
                },
                new DiceSide() {
                    Name = DiceSideConsts.Parrot
                },
                new DiceSide() {
                    Name = DiceSideConsts.Skull
                },
                new DiceSide() {
                    Name = DiceSideConsts.Swords
                }
            };
        }

        public void Roll()
        {
            FacingUp = Sides.ElementAt(new Random().Next(Sides.Count));
        }
    }
}
