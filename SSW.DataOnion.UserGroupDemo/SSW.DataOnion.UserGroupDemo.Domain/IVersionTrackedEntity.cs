using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSW.DataOnion.UserGroupDemo.Domain
{
    public interface IVersionTrackedEntity
    {

      
        byte[] RowVersion { get; set; }


    }
}
