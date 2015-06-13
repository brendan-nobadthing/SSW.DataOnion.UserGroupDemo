using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSW.DataOnion.UserGroupDemo.Domain;

namespace SSW.DataOnion.UserGroupDemo.VanillaEF.EntityConfig
{
    public class ActivityConfiguration : EntityTypeConfiguration<Activity>
    {
        public ActivityConfiguration()
        {
            ToTable("Activities");
        }
    }

    public class InSchoolActivityConfiguration : EntityTypeConfiguration<InSchoolActivity>
    {
        public InSchoolActivityConfiguration()
        {
            ToTable("InSchoolActivities");
        }
    }

    public class OutsideSchoolActivityConfiguration : EntityTypeConfiguration<OutsideSchoolActivity>
    {
        public OutsideSchoolActivityConfiguration()
        {
            ToTable("OutsideSchoolActivities");
        }
    }

}
