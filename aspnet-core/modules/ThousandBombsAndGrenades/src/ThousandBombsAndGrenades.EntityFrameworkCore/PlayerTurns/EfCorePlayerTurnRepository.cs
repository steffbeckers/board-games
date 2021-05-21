using System;
using ThousandBombsAndGrenades.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace ThousandBombsAndGrenades.PlayerTurns
{
    public class EfCorePlayerTurnRepository : EfCoreRepository<ThousandBombsAndGrenadesDbContext, PlayerTurn, Guid>, IPlayerTurnRepository
    {
        public EfCorePlayerTurnRepository(IDbContextProvider<ThousandBombsAndGrenadesDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}
