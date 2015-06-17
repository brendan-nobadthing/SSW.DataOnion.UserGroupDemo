using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSW.DataOnion.UserGroupDemo.Domain;

namespace SSW.DataOnion.UserGroupDemo.DataInterfaces.Import
{
    public interface IImportStudents
    {
        void Import(IObjectDataSource<Student> dataSource);
    }
}
