using Volo.Abp;

namespace ThousandBombsAndGrenades.Games
{
    public class GameIsFinishedException : BusinessException
    {
        public GameIsFinishedException() : base(ThousandBombsAndGrenadesErrorCodes.GameIsFinished)
        {
        }
    }
}