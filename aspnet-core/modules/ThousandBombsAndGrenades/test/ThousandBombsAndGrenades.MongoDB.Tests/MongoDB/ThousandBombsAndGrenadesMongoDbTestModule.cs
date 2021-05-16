using System;
using Volo.Abp.Data;
using Volo.Abp.Modularity;
using Volo.Abp.Uow;

namespace ThousandBombsAndGrenades.MongoDB
{
    [DependsOn(
        typeof(ThousandBombsAndGrenadesTestBaseModule),
        typeof(ThousandBombsAndGrenadesMongoDbModule)
        )]
    public class ThousandBombsAndGrenadesMongoDbTestModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var stringArray = MongoDbFixture.ConnectionString.Split('?');
            var connectionString = stringArray[0].EnsureEndsWith('/')  +
                                       "Db_" +
                                   Guid.NewGuid().ToString("N") + "/?" + stringArray[1];

            Configure<AbpDbConnectionOptions>(options =>
            {
                options.ConnectionStrings.Default = connectionString;
            });
        }
    }
}
