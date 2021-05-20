using Volo.Abp;

namespace ThousandBombsAndGrenades.PlayerTurns
{
    public class PlayerTurnHasToStartByDrawingACardFirstException : BusinessException
    {
        public PlayerTurnHasToStartByDrawingACardFirstException() : base(ThousandBombsAndGrenadesErrorCodes.PlayerTurnHasToStartByDrawingACardFirst)
        {
        }
    }
}