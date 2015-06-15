using System;
using System.Collections.Generic;
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
                var brendan = context.Students.Add(new Student()
                {
                    FirstName = "Brendan",
                    LastName = "Richards",
                    DateOfBirth = new DateTime(2002, 05, 12)
                });


                var adam = context.Students.Add(new Student()
                {
                    FirstName = "Adam",
                    LastName = "Cogan",
                    DateOfBirth = new DateTime(2004, 03, 2)
                });


                var course = context.Courses.Add(new Course()
                {
                    Title = "How To Win"
                });

                brendan.Courses = new List<Course>();
                adam.Courses = new List<Course>();
                brendan.Courses.Add(course);
                adam.Courses.Add(course);

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
