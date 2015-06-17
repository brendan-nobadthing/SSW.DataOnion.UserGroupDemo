using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSW.DataOnion.UserGroupDemo.DataInterfaces
{
    public interface IObjectDataSource<T>
    {
        IList<T> GetObjects();
    }
}
