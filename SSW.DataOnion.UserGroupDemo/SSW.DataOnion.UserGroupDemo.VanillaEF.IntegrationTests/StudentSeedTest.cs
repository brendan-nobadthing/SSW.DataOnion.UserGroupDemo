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
    public class StudentSeedTest
    {

        private IEnumerable<Student> _students; 

        void WhenIQueryStudents()
        {
            using (var context = new DemoContextFactory().Create())
            {
                _students = context.Students.ToList();
            }
        }


        private void ThenStudentsHaveBeenSeeded()
        {
            Assert.NotNull(_students);
            Assert.NotEmpty(_students);
        }



        [Fact]
        public void StudentsAreSeeded()
        {
            this.BDDfy();
        }

    }
}
