 


using SSW.DataOnion.UserGroupDemo.Domain;

using SSW.DataOnion.UserGroupDemo.DataInterfaces.Repositories;
using SSW.Data.EF;

namespace SSW.DataOnion.UserGroupDemo.EFDataOnion.Repositories
{
	public partial class ActivityRepository : SSW.Data.EF.BaseRepository<Activity>, IActivityRepository
	{
		public ActivityRepository(IDbContextManager contextmanager)
			: base(contextmanager)
		{
		}
	}
	public partial class CourseRepository : SSW.Data.EF.BaseRepository<Course>, ICourseRepository
	{
		public CourseRepository(IDbContextManager contextmanager)
			: base(contextmanager)
		{
		}
	}
	public partial class EnrolmentRepository : SSW.Data.EF.BaseRepository<Enrolment>, IEnrolmentRepository
	{
		public EnrolmentRepository(IDbContextManager contextmanager)
			: base(contextmanager)
		{
		}
	}
	public partial class InSchoolActivityRepository : SSW.Data.EF.BaseRepository<InSchoolActivity>, IInSchoolActivityRepository
	{
		public InSchoolActivityRepository(IDbContextManager contextmanager)
			: base(contextmanager)
		{
		}
	}
	public partial class OutsideSchoolActivityRepository : SSW.Data.EF.BaseRepository<OutsideSchoolActivity>, IOutsideSchoolActivityRepository
	{
		public OutsideSchoolActivityRepository(IDbContextManager contextmanager)
			: base(contextmanager)
		{
		}
	}
	public partial class SchoolRepository : SSW.Data.EF.BaseRepository<School>, ISchoolRepository
	{
		public SchoolRepository(IDbContextManager contextmanager)
			: base(contextmanager)
		{
		}
	}
	public partial class StudentRepository : SSW.Data.EF.BaseRepository<Student>, IStudentRepository
	{
		public StudentRepository(IDbContextManager contextmanager)
			: base(contextmanager)
		{
		}
	}
}

