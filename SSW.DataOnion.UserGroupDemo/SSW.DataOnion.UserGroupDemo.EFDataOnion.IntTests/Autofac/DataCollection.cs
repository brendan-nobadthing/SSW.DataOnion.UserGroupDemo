using Xunit;

namespace SSW.DataOnion.UserGroupDemo.EFDataOnion.IntTests.Autofac
{

    [CollectionDefinition("DataCollection")]
    public class DataCollection : ICollectionFixture<DataFixture>
    {
    }

}