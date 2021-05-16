using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Repositories;

namespace ThousandBombsAndGrenades.Games
{
    public interface IGameRepository : IRepository<Game, Guid>
    {
    }
}
