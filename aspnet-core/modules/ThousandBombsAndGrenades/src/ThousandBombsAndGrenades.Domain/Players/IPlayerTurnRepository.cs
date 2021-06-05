using System;
using Volo.Abp.Domain.Repositories;

namespace ThousandBombsAndGrenades.Players
{
    public interface IPlayerRepository : IRepository<Player, Guid>
    {
    }
}
