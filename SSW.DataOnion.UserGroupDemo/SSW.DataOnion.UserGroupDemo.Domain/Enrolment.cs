using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSW.DataOnion.UserGroupDemo.Domain
{
    public class Enrolment
    {

        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }


        public virtual School School { get; set; }

        public virtual Student Student { get; set; }

    }

}
