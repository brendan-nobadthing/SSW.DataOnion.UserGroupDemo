using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace SSW.DataOnion.UserGroupDemo.VanillaEF.cs
{
    public class DemoContextFactory : IDbContextFactory<DemoContext>
    {

        private static bool _hasSetInitializer = false;

        public DemoContext Create()
        {

            if (!_hasSetInitializer)
            {
                System.Data.Entity.Database.SetInitializer<DemoContext>(new DemoDropCreateAlways());
                //System.Data.Entity.Database.SetInitializer<DemoContext>(new DropCreateDatabaseIfModelChanges<DemoContext>());
                _hasSetInitializer = true;
            }

            return new DemoContext();
        }
    }
}
