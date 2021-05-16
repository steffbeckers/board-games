using System;
using System.Collections.Generic;
using System.Text;
using BoardGames.Localization;
using Volo.Abp.Application.Services;

namespace BoardGames
{
    /* Inherit your application services from this class.
     */
    public abstract class BoardGamesAppService : ApplicationService
    {
        protected BoardGamesAppService()
        {
            LocalizationResource = typeof(BoardGamesResource);
        }
    }
}
