using SSW.DataOnion.UserGroupDemo.Domain;

namespace SSW.DataOnion.UserGroupDemo.EFDataOnion
{
    using System;
    using System.Data.Common;
    using System.Data.Entity;
    using System.Data.Entity.Core.Objects;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Reflection;
    using System.Web;

    using SSW.Data.Entities;

    /// <summary>
    /// Database context - rename to match the dbcontext name in 
    /// </summary>
    public partial class DataOnionDbContext : DbContext
    {
        ///// <summary>
        ///// Initializes a new instance of the <see cref="YourDbContext"/> class.
        ///// </summary>
        //public YourDbContext()
        //    : base("name=YourConnectionStringName")
        //{
            
        //}

        /// <summary>
        /// Initializes a new instance of the <see cref="YourDbContext" /> class.
        /// </summary>
        /// <param name="connection">The connection.</param>
        public DataOnionDbContext(DbConnection connection)
            : base(connection, true)
        {
            this.Configuration.LazyLoadingEnabled = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="YourDbContext"/> class.
        /// </summary>
        /// <param name="connectionString">
        /// The connection string.
        /// </param>
        public DataOnionDbContext(string connectionString)
            : base(connectionString)
        {
			this.Configuration.LazyLoadingEnabled = true;
        }

        

        /// <summary>
        /// This method is called when the model for a derived context has been initialized,
        /// but
        /// before the model has been locked down and used to initialize the context.  The
        /// default
        /// implementation of this method does nothing, but it can be overridden in a derived
        /// class
        /// such that the model can be further configured before it is locked down.
        /// </summary>
        /// <param name="modelBuilder">The builder that defines the model for the context
        /// being created.</param>
        /// <remarks>
        /// Typically, this method is called only once when the first instance of a derived
        /// context
        /// is created.  The model for that context is then cached and is for all further
        /// instances of
        /// the context in the app domain.  This caching can be disabled by setting the ModelCaching
        /// property on the given ModelBuiller, but note that this can seriously degrade
        /// performance.
        /// More control over caching is provided through use of the DbModelBuilder and DbContextFactory
        /// classes directly.
        /// </remarks>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }



        public override int SaveChanges()
        {

            // concurrency check for IPersistentEntity - we need to copy the posted rowversion to entity's original values.
            var changedPersistentEntities = ChangeTracker.Entries()
                .Where(
                    x =>
                        x.Entity is IVersionTrackedEntity && x.State == EntityState.Modified)
                .ToList();
            foreach (var e in changedPersistentEntities)
            {
                if (e.OriginalValues["RowVersion"] != e.CurrentValues["RowVersion"])
                {
                    e.OriginalValues["RowVersion"] = ((IVersionTrackedEntity)e.Entity).RowVersion;
                }
            }

            return base.SaveChanges();
        }


    }
}
