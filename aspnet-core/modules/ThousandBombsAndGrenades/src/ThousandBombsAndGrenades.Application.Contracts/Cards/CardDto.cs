using System;
using System.Collections.Generic;
using System.Text;

namespace ThousandBombsAndGrenades.Cards
{
    public class CardDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public int? Points { get; set; }
        public int? Count { get; set; }
    }
}
