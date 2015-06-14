using System;
using System.Data.Entity;
using System.Linq;
using SSW.DataOnion.UserGroupDemo.Domain;

namespace SSW.DataOnion.UserGroupDemo.EFDataOnion
{
    public class DemoDropCreateAlways : DropCreateDatabaseAlways<DataOnionDbContext>
    {


        protected override void Seed(DataOnionDbContext context)
        {

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

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
