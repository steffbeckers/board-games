using System;
using Volo.Abp.Domain.Repositories;

namespace ThousandBombsAndGrenades.Games
{
    public interface IGameRepository : IRepository<Game, Guid>
    {
    }
}
