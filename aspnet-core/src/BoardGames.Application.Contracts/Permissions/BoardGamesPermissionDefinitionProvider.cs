using BoardGames.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace BoardGames.Permissions
{
    public class BoardGamesPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(BoardGamesPermissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(BoardGamesPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<BoardGamesResource>(name);
        }
    }
}
