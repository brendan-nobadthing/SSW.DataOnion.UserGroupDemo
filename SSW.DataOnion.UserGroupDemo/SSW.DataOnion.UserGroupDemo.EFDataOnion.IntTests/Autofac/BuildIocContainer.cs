using System.Reflection;
using Autofac;
using SSW.DataOnion.UserGroupDemo.DependencyResolution;

namespace SSW.DataOnion.UserGroupDemo.EFDataOnion.IntTests.Autofac
{
    public class BuildIocContainer
    {

        public static IContainer BuildContainer()
        {


            var builder = new ContainerBuilder();
            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());

            builder.RegisterModule(new DataOnionModule(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString.ToString()));

            return builder.Build();
        }
    }
}