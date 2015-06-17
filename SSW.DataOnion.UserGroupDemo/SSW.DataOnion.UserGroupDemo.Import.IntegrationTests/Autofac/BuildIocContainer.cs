using System.Reflection;
using Autofac;
using Serilog;
using SSW.DataOnion.UserGroupDemo.DependencyResolution;

namespace SSW.DataOnion.UserGroupDemo.Import.IntegrationTests.Autofac
{
    public class BuildIocContainer
    {

        public static IContainer BuildContainer()
        {


            var builder = new ContainerBuilder();
            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());

            builder.RegisterModule(new DataOnionModule(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString.ToString()));

            builder.RegisterModule(new SerilogModule(System.Configuration.ConfigurationManager.AppSettings["LogFile"], System.Configuration.ConfigurationManager.AppSettings["SeqUrl"]));

            var container = builder.Build();

            // use log via lookup to trigger global static config
            container.Resolve<ILogger>()
                .ForContext<BuildIocContainer>()
                .Information("=== autofac container built ===");

            return container;
        }
    }
}