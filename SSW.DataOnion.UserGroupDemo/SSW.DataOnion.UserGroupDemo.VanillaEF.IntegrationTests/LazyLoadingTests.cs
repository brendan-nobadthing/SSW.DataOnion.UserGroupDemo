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
    public class LazyLoadingTests
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


        void ThenEnrolmentsareLazyLoaded()
        {
            using (var context = new DemoContextFactory().Create())
            {
                var brendan = context.Students.FirstOrDefault(s => s.FirstName == "Brendan");

                // put breakpoint here
                Assert.NotNull(brendan);
                Assert.NotEmpty(brendan.Enrolments);
                Console.Out.WriteLine(string.Format("entity type {0}", brendan.GetType().FullName));
                Console.Out.WriteLine(string.Format("collection Type: {0}",brendan.Enrolments.GetType().FullName));
                
            }
        }

        [Fact]
        public void Run()
        {
            this.BDDfy();
        }


    }
}
