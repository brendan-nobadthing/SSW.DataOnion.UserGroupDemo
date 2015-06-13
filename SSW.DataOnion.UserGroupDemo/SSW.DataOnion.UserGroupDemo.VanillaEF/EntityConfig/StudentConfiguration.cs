using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSW.DataOnion.UserGroupDemo.Domain;

namespace SSW.DataOnion.UserGroupDemo.VanillaEF.EntityConfig
{
    public class StudentConfiguration : EntityTypeConfiguration<Student>
    {

        public StudentConfiguration()
        {
            Property(s => s.LastName).HasMaxLength(222);
        }
    }
}
