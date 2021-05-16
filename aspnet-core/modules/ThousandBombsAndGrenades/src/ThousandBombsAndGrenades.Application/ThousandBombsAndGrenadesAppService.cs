using ThousandBombsAndGrenades.Localization;
using Volo.Abp.Application.Services;

namespace ThousandBombsAndGrenades
{
    public abstract class ThousandBombsAndGrenadesAppService : ApplicationService
    {
        protected ThousandBombsAndGrenadesAppService()
        {
            LocalizationResource = typeof(ThousandBombsAndGrenadesResource);
            ObjectMapperContext = typeof(ThousandBombsAndGrenadesApplicationModule);
        }
    }
}
