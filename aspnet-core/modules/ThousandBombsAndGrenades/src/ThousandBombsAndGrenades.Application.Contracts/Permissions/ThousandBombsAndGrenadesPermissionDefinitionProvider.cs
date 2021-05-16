using ThousandBombsAndGrenades.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace ThousandBombsAndGrenades.Permissions
{
    public class ThousandBombsAndGrenadesPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(ThousandBombsAndGrenadesPermissions.GroupName, L("Permission:ThousandBombsAndGrenades"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<ThousandBombsAndGrenadesResource>(name);
        }
    }
}