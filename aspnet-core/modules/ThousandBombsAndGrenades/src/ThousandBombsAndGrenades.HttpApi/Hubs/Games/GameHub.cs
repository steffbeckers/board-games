using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Primitives;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.SignalR;

namespace ThousandBombsAndGrenades.Hubs.Games
{
    [HubRoute("/api/games/thousand-bombs-and-grenades/hubs/game")]
    public class GameHub : AbpHub
    {
        public override async Task OnConnectedAsync()
        {
            HttpContext httpContext = Context.GetHttpContext();

            httpContext.Request.Headers.TryGetValue("gameId", out StringValues gameIdStringValues);
            string gameId = gameIdStringValues.FirstOrDefault();

            if (string.IsNullOrEmpty(gameId))
            {
                httpContext.Request.Query.TryGetValue("gameId", out gameIdStringValues);
                gameId = gameIdStringValues.FirstOrDefault();
            }

            if (!string.IsNullOrEmpty(gameId))
            {
                gameId = gameId.ToUpper();

                await Groups.AddToGroupAsync(Context.ConnectionId, gameId);
            }

            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            HttpContext httpContext = Context.GetHttpContext();

            httpContext.Request.Headers.TryGetValue("gameId", out StringValues gameIdStringValues);
            string gameId = gameIdStringValues.FirstOrDefault();

            if (string.IsNullOrEmpty(gameId))
            {
                httpContext.Request.Query.TryGetValue("gameId", out gameIdStringValues);
                gameId = gameIdStringValues.FirstOrDefault();
            }

            if (!string.IsNullOrEmpty(gameId))
            {
                gameId = gameId.ToUpper();

                await Groups.RemoveFromGroupAsync(Context.ConnectionId, gameId);
            }

            await base.OnDisconnectedAsync(exception);
        }
    }
}
