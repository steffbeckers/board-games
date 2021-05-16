using Volo.Abp;

namespace ThousandBombsAndGrenades.Games
{
    public class GameCantStartWithMoreThanXPlayersException : BusinessException
    {
        public GameCantStartWithMoreThanXPlayersException(int maxPlayerCount) : base(ThousandBombsAndGrenadesErrorCodes.GameCantStartWithMoreThanXPlayers)
        {
            WithData("maxPlayerCount", maxPlayerCount);
        }
    }
}