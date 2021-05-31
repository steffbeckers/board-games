using Volo.Abp.AspNetCore.SignalR;

namespace ThousandBombsAndGrenades.Hubs.Games
{
    [HubRoute("/api/games/thousand-bombs-and-grenades/hubs/game")]
    public class GameHub : AbpHub
    {
    }
}
