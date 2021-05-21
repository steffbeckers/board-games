using System;
using Volo.Abp.Domain.Repositories;

namespace ThousandBombsAndGrenades.PlayerTurns
{
    public interface IPlayerTurnRepository : IRepository<PlayerTurn, Guid>
    {
    }
}
