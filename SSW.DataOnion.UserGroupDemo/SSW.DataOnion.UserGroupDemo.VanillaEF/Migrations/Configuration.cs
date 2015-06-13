using SSW.DataOnion.UserGroupDemo.Domain;

namespace SSW.DataOnion.UserGroupDemo.VanillaEF.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SSW.DataOnion.UserGroupDemo.VanillaEF.DemoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "SSW.DataOnion.UserGroupDemo.VanillaEF.DemoContext";
        }

        protected override void Seed(SSW.DataOnion.UserGroupDemo.VanillaEF.DemoContext context)
        {
            //  This method will be called after migrating to the latest version.


            if (!context.Students.Any())
            {
                context.Students.Add(new Student()
                {
                    FirstName = "Brendan",
                    LastName = "Richards",
                    DateOfBirth = new DateTime(2002, 05, 12)
                });


                context.Students.Add(new Student()
                {
                    FirstName = "Adam",
                    LastName = "Cogan",
                    DateOfBirth = new DateTime(2004, 03, 2)
                });


                context.Courses.Add(new Course()
                {
                    Title = "How To Win"
                });

                context.Schools.Add(new School()
                {
                    Name = "School Of Rock"
                });


                context.SaveChanges();
                
            }
            
        }
    }
}
