using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;

namespace SSW.DataOnion.UserGroupDemo.WebUI
{
    public class AutofacConfig
    {


        public static void Configure()
        {


            var builder = new ContainerBuilder();

            // REGISTER your MVC controllers.
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // OPTIONAL: REGISTER model binders that require DI.
            //builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            //builder.RegisterModelBinderProvider();

            // OPTIONAL: REGISTER web abstractions like HttpContextBase.
            builder.RegisterModule<AutofacWebTypesModule>();

            // OPTIONAL: Enable property injection in view pages.
            builder.RegisterSource(new ViewRegistrationSource());

            // OPTIONAL: Enable property injection into action filters.
            builder.RegisterFilterProvider();

            builder.RegisterModule(new SSW.DataOnion.UserGroupDemo.DependencyResolution.DataOnionModule(
                System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString.ToString()
            ));

            

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));



        }

    }
}