using System;

namespace ThousandBombsAndGrenades.Games
{
    [Serializable]
    public class GameEto
    {
        public Guid Id { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
