using Volo.Abp.Reflection;

namespace ThousandBombsAndGrenades.Permissions
{
    public class ThousandBombsAndGrenadesPermissions
    {
        public const string GroupName = "ThousandBombsAndGrenades";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(ThousandBombsAndGrenadesPermissions));
        }
    }
}