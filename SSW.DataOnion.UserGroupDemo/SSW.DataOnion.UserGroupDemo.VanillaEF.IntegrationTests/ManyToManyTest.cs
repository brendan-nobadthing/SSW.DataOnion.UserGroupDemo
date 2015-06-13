using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using SSW.DataOnion.UserGroupDemo.Domain;
using SSW.DataOnion.UserGroupDemo.VanillaEF;
using TestStack.BDDfy;
using Xunit;

namespace SSW.DataOnion.UserGroupDemo.VanillaEF.IntegrationTests
{
    public class ManyToManyTest
    {


        [Fact]
        public void DoManyToManyTest()
        {

            DropDatabase.DropDb();

            using (var context = new DemoContextFactory().Create())
            {
                var brendan = context.Students.FirstOrDefault(s => s.FirstName == "Brendan");
                var adam = context.Students.FirstOrDefault(s => s.FirstName == "Adam");

                var course = context.Courses.FirstOrDefault(c => c.Title == "How To Win");

                Assert.NotNull(brendan);
                Assert.NotNull(adam);
                Assert.NotNull(course);

                course.Students.Add(brendan);
                course.Students.Add(adam);

                context.SaveChanges();
            }


            using (var context2 = new DemoContextFactory().Create())
            {
                var course = context2.Courses.FirstOrDefault(c => c.Title == "How To Win");

                Assert.Equal(2, course.Students.Count());
            }

        }

    }
}
