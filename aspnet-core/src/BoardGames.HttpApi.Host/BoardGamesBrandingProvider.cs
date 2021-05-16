using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace BoardGames
{
    [Dependency(ReplaceServices = true)]
    public class BoardGamesBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "BoardGames";
    }
}
