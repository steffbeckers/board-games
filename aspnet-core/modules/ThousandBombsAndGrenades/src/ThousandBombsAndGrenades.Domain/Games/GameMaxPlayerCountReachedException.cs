using Volo.Abp;

namespace ThousandBombsAndGrenades.Games
{
    public class GameMaxPlayerCountReachedException : BusinessException
    {
        public GameMaxPlayerCountReachedException(int maxPlayerCount) : base(ThousandBombsAndGrenadesErrorCodes.GameMaxPlayerCountReached)
        {
            WithData("maxPlayerCount", maxPlayerCount);
        }
    }
}