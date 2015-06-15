using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using SSW.Data.Interfaces;
using SSW.DataOnion.UserGroupDemo.DataInterfaces.Repositories;
using SSW.DataOnion.UserGroupDemo.Domain;

namespace SSW.DataOnion.UserGroupDemo.WebUI.ViewModels
{
    public class StudentVm
    {

        public int Id { get; set; } 

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int CountCourses { get; set; }

        public int CountActivities { get; set; }

    }



    public interface IStudentVmMapper
    {
        StudentVm GetViewModel(int id);

        StudentVm ToViewModel(Student entity);

        Student SaveViewModel(StudentVm model);

        IQueryable<StudentVm> GetList();

    }



    public class StudentVmMapper : IStudentVmMapper
    {

        private readonly IStudentRepository _studentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public StudentVmMapper(IStudentRepository studentRepository, 
            IUnitOfWork unitOfWork)
        {
            _studentRepository = studentRepository;
            _unitOfWork = unitOfWork;
        }

        public StudentVm GetViewModel(int id)
        {
            var entity = _studentRepository.Find(id);
            return this.ToViewModel(entity);
        }

        public StudentVm ToViewModel(Student entity)
        {
            return ViewModelProjection.Compile().Invoke(entity);
        }


        public Student SaveViewModel(StudentVm model)
        {
            var entity = model.Id > 0
                ? _studentRepository.Find(model.Id)
                : new Student();

            entity.FirstName = model.FirstName;
            entity.LastName = model.LastName;

            return entity;
        }


        public IQueryable<StudentVm> GetList()
        {
            return _studentRepository.Get()
                .Select(ViewModelProjection);
        }


        protected   Expression<Func<Student, StudentVm>> ViewModelProjection {
            get
            {
                return s => new StudentVm()
                {
                    Id = s.Id,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    CountActivities = s.Activities.Count(), 
                    CountCourses = s.Courses.Count()
                };
            }
        }

    }

}