using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSW.DataOnion.UserGroupDemo.Domain;
using TestStack.BDDfy;
using Xunit;

namespace SSW.DataOnion.UserGroupDemo.VanillaEF.IntegrationTests
{
    public class ManualReferenceLoading
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


        void ThenICanManuallyLoadReferences()
        {
            using (var context = new DemoContextFactory().Create())
            {
                context.Configuration.LazyLoadingEnabled = false;

                var brendan = context.Students.FirstOrDefault(s => s.FirstName == "Brendan");

                Assert.Null(brendan.Enrolments);

                context.Entry(brendan).Collection(s => s.Enrolments).Load();

                Assert.NotNull(brendan.Enrolments);
                Assert.NotEmpty(brendan.Enrolments);
            }
        }

        [Fact]
        public void Run()
        {
            this.BDDfy();
        }


    }
}
