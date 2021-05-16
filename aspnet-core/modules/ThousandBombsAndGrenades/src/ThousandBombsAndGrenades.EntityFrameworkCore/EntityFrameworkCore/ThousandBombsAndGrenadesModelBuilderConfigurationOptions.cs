using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace ThousandBombsAndGrenades.EntityFrameworkCore
{
    public class ThousandBombsAndGrenadesModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public ThousandBombsAndGrenadesModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}