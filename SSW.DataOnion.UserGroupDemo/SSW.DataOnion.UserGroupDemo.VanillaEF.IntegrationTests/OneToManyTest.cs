using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSW.DataOnion.UserGroupDemo.Domain;
using SSW.DataOnion.UserGroupDemo.VanillaEF;
using Xunit;

namespace SSW.DataOnion.UserGroupDemo.VanillaEF.IntegrationTests
{
    public class OneToManyTest
    {


        [Fact]
        public void DoOneToManyTest()
        {

            DropDatabase.DropDb();

            using (var context = new DemoContextFactory().Create())
            {
                var student = context.Students.FirstOrDefault(s => s.FirstName == "Brendan");

                Assert.NotNull(student);

                student.Enrolments.Add(new Enrolment()
                {
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddYears(1),
                    School = context.Schools.FirstOrDefault(s => s.Name == "School Of Rock")
                });

                context.SaveChanges();

            }
        }

    }
}
