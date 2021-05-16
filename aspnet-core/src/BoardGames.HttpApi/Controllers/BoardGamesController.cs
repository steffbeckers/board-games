using BoardGames.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace BoardGames.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class BoardGamesController : AbpController
    {
        protected BoardGamesController()
        {
            LocalizationResource = typeof(BoardGamesResource);
        }
    }
}