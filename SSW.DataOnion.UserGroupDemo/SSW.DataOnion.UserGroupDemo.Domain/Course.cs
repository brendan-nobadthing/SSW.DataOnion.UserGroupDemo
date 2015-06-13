using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSW.DataOnion.UserGroupDemo.Domain
{
    public class Course
    {

        public int Id { get; set; }


        public string Title { get; set; }


        public virtual School School { get; set; }


        public virtual ICollection<Student> Students { get; set; }


    }
}
