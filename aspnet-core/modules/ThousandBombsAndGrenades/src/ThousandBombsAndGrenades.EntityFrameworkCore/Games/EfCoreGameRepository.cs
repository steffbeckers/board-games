using System;
using ThousandBombsAndGrenades.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace ThousandBombsAndGrenades.Games
{
    public class EfCoreGameRepository : EfCoreRepository<ThousandBombsAndGrenadesDbContext, Game, Guid>, IGameRepository
    {
        public EfCoreGameRepository(IDbContextProvider<ThousandBombsAndGrenadesDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}
