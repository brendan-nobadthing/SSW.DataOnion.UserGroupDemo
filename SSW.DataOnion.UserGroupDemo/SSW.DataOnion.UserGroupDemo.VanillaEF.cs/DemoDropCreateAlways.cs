using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using SSW.DataOnion.UserGroupDemo.Domain;

namespace SSW.DataOnion.UserGroupDemo.VanillaEF.cs
{
    public class DemoDropCreateAlways : DropCreateDatabaseAlways<DemoContext>
    {


        protected override void Seed(DemoContext context)
        {

            context.Students.Add(new Student()
            {
                FirstName = "Brendan",
                LastName = "Richards",
                DateOfBirth = new DateTime(1977, 01, 11)
            });


            context.Schools.Add(new School()
            {
                Name = "School Of Rock"
            });


            context.SaveChanges();

            base.Seed(context);
        }
    }
}
