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
    public class InheritanceTests
    {


        void GivenBrendanHasActivities()
        {
            DropDatabase.DropDb();
            using (var context = new DemoContextFactory().Create())
            {
                var brendan = context.Students.FirstOrDefault(s => s.FirstName == "Brendan");

                Assert.NotNull(brendan);

                brendan.Activities.Add(new InSchoolActivity()
                {
                    Name="Computer Club",
                    ClassRoom = "1A"
                });
                brendan.Activities.Add(new InSchoolActivity()
                {
                    Name = "Music Lessons",
                    ClassRoom = "C#"
                });
                brendan.Activities.Add(new OutsideSchoolActivity()
                {
                    Name = "Rowing Club",
                    ResponsiblePerson = "Mr Cox"
                });

                context.SaveChanges();
            }
        }


        void ThenICanQueryAll()
        {
            using (var context = new DemoContextFactory().Create())
            {
                var brendan = context.Students.FirstOrDefault(s => s.FirstName == "Brendan");
                Assert.NotNull(brendan.Activities);
                Assert.Equal(3, brendan.Activities.Count());
            }
        }

        void AndThenICanQueryByType()
        {
            using (var context = new DemoContextFactory().Create())
            {
                var brendan = context.Students.FirstOrDefault(s => s.FirstName == "Brendan");

                var inSchoolActivities = brendan.Activities.OfType<InSchoolActivity>();
                Assert.Equal(2, inSchoolActivities.Count());

                var outsideSchoolActivities = brendan.Activities.OfType<OutsideSchoolActivity>();
                Assert.Equal(1, outsideSchoolActivities.Count());
            }
        }

        [Fact]
        public void Run()
        {
            this.BDDfy();
        }


    }
}
