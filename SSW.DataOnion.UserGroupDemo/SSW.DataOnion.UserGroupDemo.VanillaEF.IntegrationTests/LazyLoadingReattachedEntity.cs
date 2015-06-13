using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSW.DataOnion.UserGroupDemo.Domain;
using TestStack.BDDfy;
using Xunit;
using System.Threading.Tasks;

namespace SSW.DataOnion.UserGroupDemo.VanillaEF.IntegrationTests
{
    public class LazyLoadingReattachedEntity
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


        void ThenReattachedEntitiesCanBeLazyLoadedLazyLoaded()
        {
            Student brendan;

            using (var context = new DemoContextFactory().Create())
            {
                brendan = context.Students.FirstOrDefault(s => s.FirstName == "Brendan");    
            }

            using (var context = new DemoContextFactory().Create())
            {
                context.Students.Attach(brendan);
                Assert.NotEmpty(brendan.Enrolments);
            }
        }

        [Fact]
        public void Run()
        {
            // TODO: why is this not working?
            //Assert.Throws<Exception>(() => this.BDDfy());

            this.BDDfy();
        }


    }
}
