 

using SSW.DataOnion.UserGroupDemo.Domain;
using SSW.Data.Interfaces;

namespace SSW.DataOnion.UserGroupDemo.DataInterfaces.Repositories
{
	public partial interface IActivityRepository : IRepository<Activity>
	{
	}
	public partial interface ICourseRepository : IRepository<Course>
	{
	}
	public partial interface IEnrolmentRepository : IRepository<Enrolment>
	{
	}
	public partial interface IInSchoolActivityRepository : IRepository<InSchoolActivity>
	{
	}
	public partial interface IOutsideSchoolActivityRepository : IRepository<OutsideSchoolActivity>
	{
	}
	public partial interface ISchoolRepository : IRepository<School>
	{
	}
	public partial interface IStudentRepository : IRepository<Student>
	{
	}
}

