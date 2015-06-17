using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSW.DataOnion.UserGroupDemo.DataInterfaces.Import;
using SSW.DataOnion.UserGroupDemo.Domain;

namespace SSW.DataOnion.UserGroupDemo.DataInterfaces.Repositories
{
    partial interface IStudentRepository
    {

        void ImportStudents(IEnumerable<Student> students);

    }
}
