using Volo.Abp;

namespace ThousandBombsAndGrenades.Games
{
    public class GameCantStartWithoutPlayersException : BusinessException
    {
        public GameCantStartWithoutPlayersException() : base(ThousandBombsAndGrenadesErrorCodes.GameCantStartWithoutPlayers)
        {
        }
    }
}