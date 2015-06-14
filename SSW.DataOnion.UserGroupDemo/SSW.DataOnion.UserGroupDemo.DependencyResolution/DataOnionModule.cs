using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using SSW.Data.EF;
using SSW.Data.Interfaces;
using SSW.DataOnion.UserGroupDemo.DataInterfaces.Repositories;
using SSW.DataOnion.UserGroupDemo.EFDataOnion;
using SSW.DataOnion.UserGroupDemo.EFDataOnion.Repositories;
using Module = Autofac.Module;

namespace SSW.DataOnion.UserGroupDemo.DependencyResolution
{
    public class DataOnionModule : Module
    {
        


        private readonly string _connectionString;

        public DataOnionModule(string connectionString)
        {
            _connectionString = connectionString;
        }




        protected override void Load(ContainerBuilder builder)
        {

            // initializer
            // TODO - replace this with Migrations
            builder.RegisterType<DemoDropCreateAlways>().As<IDatabaseInitializer<DataOnionDbContext>>();


            // factory
            builder.RegisterType<SSW.Data.EF.DbContextFactory<DataOnionDbContext>>()
                .WithParameter("connectionString", _connectionString)
                .As<IDbContextFactory<DataOnionDbContext>>();
              
            // manager
            builder.RegisterType<DbContextManager<DataOnionDbContext>>()
                .As<IDbContextManager<DataOnionDbContext>>()
                .As<IDbContextManager>()
                .InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();



            // scan for repositories
            builder.RegisterAssemblyTypes(
                Assembly.GetAssembly(typeof(SchoolRepository)),
                Assembly.GetAssembly(typeof(ISchoolRepository)))
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();

        }
    }



}
