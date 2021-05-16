using System.Runtime.Serialization;

namespace ThousandBombsAndGrenades
{
    public static class ThousandBombsAndGrenadesErrorCodes
    {
        // Add your business exception error codes here...
        public const string GameCantStartWithoutPlayers = "ThousandBombsAndGrenades:Game:00001";
        public const string GameCantStartWithoutNumberOfPlayers = "ThousandBombsAndGrenades:Game:00002";
        public const string GameCantStartWithMoreThanXPlayers = "ThousandBombsAndGrenades:Game:00003";
        public const string GameMaxPlayerCountReached = "ThousandBombsAndGrenades:Game:00004";
        public const string GameHasAlreadyStarted = "ThousandBombsAndGrenades:Game:00005";
        public const string GameIsFinished = "ThousandBombsAndGrenades:Game:00006";
    }
}
