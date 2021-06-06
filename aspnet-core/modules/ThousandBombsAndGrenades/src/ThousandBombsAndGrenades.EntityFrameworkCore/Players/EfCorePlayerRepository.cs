using System;
using ThousandBombsAndGrenades.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace ThousandBombsAndGrenades.Players
{
    public class EfCorePlayerRepository : EfCoreRepository<ThousandBombsAndGrenadesDbContext, Player, Guid>, IPlayerRepository
    {
        public EfCorePlayerRepository(IDbContextProvider<ThousandBombsAndGrenadesDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}
