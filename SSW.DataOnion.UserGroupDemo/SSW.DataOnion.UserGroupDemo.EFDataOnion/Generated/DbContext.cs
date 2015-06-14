 

namespace SSW.DataOnion.UserGroupDemo.EFDataOnion
{
	using System.Data.Entity;
	
		using SSW.DataOnion.UserGroupDemo.Domain;


	using SSW.Data.Entities;

	public partial class DataOnionDbContext
	{
		public IDbSet<Activity> Activitys { get; set; }

		public IDbSet<Course> Courses { get; set; }

		public IDbSet<Enrolment> Enrolments { get; set; }

		public IDbSet<InSchoolActivity> InSchoolActivitys { get; set; }

		public IDbSet<OutsideSchoolActivity> OutsideSchoolActivitys { get; set; }

		public IDbSet<School> Schools { get; set; }

		public IDbSet<Student> Students { get; set; }

	}
}

