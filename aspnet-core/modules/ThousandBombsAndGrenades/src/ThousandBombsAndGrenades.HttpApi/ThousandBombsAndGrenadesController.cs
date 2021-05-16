using ThousandBombsAndGrenades.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ThousandBombsAndGrenades
{
    public abstract class ThousandBombsAndGrenadesController : AbpController
    {
        protected ThousandBombsAndGrenadesController()
        {
            LocalizationResource = typeof(ThousandBombsAndGrenadesResource);
        }
    }
}
