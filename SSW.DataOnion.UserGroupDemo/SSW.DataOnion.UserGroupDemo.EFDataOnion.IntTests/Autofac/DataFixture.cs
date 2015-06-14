using System;
using Autofac;

namespace SSW.DataOnion.UserGroupDemo.EFDataOnion.IntTests.Autofac
{

    /// <summary>
    /// https://github.com/daniel-chambers/xunit.ioc does not currently work as xunit 2 removes RunWith attr.
    /// So this is a data fixture for sharing context between tests with a simple autofac service locator.
    /// as per http://xunit.github.io/docs/shared-context.html
    /// </summary>
    public class DataFixture : IDisposable
    {

        private readonly  IContainer _container;

        public DataFixture()
        {
            _container = BuildIocContainer.BuildContainer();
        }


        public T GetDependency<T>()
        {
            return _container.Resolve<T>();
        }

        public void Dispose()
        {
            if (_container != null) _container.Dispose();
        }
    }
}