using ThousandBombsAndGrenades.Samples;
using Xunit;

namespace ThousandBombsAndGrenades.MongoDB.Samples
{
    [Collection(MongoTestCollection.Name)]
    public class SampleRepository_Tests : SampleRepository_Tests<ThousandBombsAndGrenadesMongoDbTestModule>
    {
        /* Don't write custom repository tests here, instead write to
         * the base class.
         * One exception can be some specific tests related to MongoDB.
         */
    }
}
