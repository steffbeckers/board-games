using Volo.Abp;

namespace ThousandBombsAndGrenades.Games
{
    public class GameHasAlreadyStartedException : BusinessException
    {
        public GameHasAlreadyStartedException() : base(ThousandBombsAndGrenadesErrorCodes.GameHasAlreadyStarted)
        {
        }
    }
}