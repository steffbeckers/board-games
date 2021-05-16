using Volo.Abp;

namespace ThousandBombsAndGrenades.Games
{
    public class GameCantStartWithoutNumberOfPlayersException : BusinessException
    {
        public GameCantStartWithoutNumberOfPlayersException(int minPlayerCount) : base(ThousandBombsAndGrenadesErrorCodes.GameCantStartWithoutNumberOfPlayers)
        {
            WithData("minPlayerCount", minPlayerCount);
        }
    }
}