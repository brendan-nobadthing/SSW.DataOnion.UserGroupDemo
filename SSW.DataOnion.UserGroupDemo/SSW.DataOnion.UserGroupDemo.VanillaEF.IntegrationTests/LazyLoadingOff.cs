using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSW.DataOnion.UserGroupDemo.Domain;
using TestStack.BDDfy;
using Xunit;

namespace SSW.DataOnion.UserGroupDemo.VanillaEF.IntegrationTests
{
    public class LazyLoadingOff
    {


        void GivenBrendanHasEnrolments()
        {
            DropDatabase.DropDb();
            using (var context = new DemoContextFactory().Create())
            {
                var brendan = context.Students.FirstOrDefault(s => s.FirstName == "Brendan");

                Assert.NotNull(brendan);

                brendan.Enrolments.Add(new Enrolment()
                {
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddYears(1)
                });

                brendan.Enrolments.Add(new Enrolment()
                {
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddYears(1)
                });

                context.SaveChanges();
            }
        }


        void ThenEnrolmentsIsNullWithLazyLoadingOff()
        {
            using (var context = new DemoContextFactory().Create())
            {
                context.Configuration.LazyLoadingEnabled = false;

                var brendan = context.Students.FirstOrDefault(s => s.FirstName == "Brendan");
                Assert.Null(brendan.Enrolments);
            }
        }

        [Fact]
        public void Run()
        {
            this.BDDfy();
        }


    }
}
