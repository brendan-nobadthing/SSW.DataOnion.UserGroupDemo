using Xunit;

namespace SSW.DataOnion.UserGroupDemo.Import.IntegrationTests.Autofac
{

    [CollectionDefinition("DataCollection")]
    public class DataCollection : ICollectionFixture<DataFixture>
    {
    }

}