using Volo.Abp.Settings;

namespace BoardGames.Settings
{
    public class BoardGamesSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(BoardGamesSettings.MySetting1));
        }
    }
}
