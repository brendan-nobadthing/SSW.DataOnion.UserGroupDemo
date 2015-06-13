using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSW.DataOnion.UserGroupDemo.Domain;

namespace SSW.DataOnion.UserGroupDemo.VanillaEF
{
    public class DemoContext : DbContext
    {

        public DemoContext(string connectionStringName)
            : base(connectionStringName)
        {
            this.Configuration.LazyLoadingEnabled = true;
        }



        public DemoContext()
            : base("name=DefaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Assembly);
        }


        public IDbSet<Student> Students { get; set; }

        public IDbSet<Enrolment> Enrolments { get; set; }

        public IDbSet<School> Schools { get; set; }

        public IDbSet<Course> Courses { get; set; }


    }
}
