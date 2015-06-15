using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SSW.Data.Interfaces;
using SSW.DataOnion.UserGroupDemo.DataInterfaces.Repositories;
using SSW.DataOnion.UserGroupDemo.Domain;

namespace SSW.DataOnion.UserGroupDemo.WebUI.Controllers
{

   

    public class StudentController : Controller
    {

        private readonly IStudentRepository _studentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public StudentController(IStudentRepository studentRepository, IUnitOfWork unitOfWork)
        {
            _studentRepository = studentRepository;
            _unitOfWork = unitOfWork;
        }

        // GET: Default
        public ActionResult Index()
        {
            return View(_studentRepository.Get());
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var student = _studentRepository.Find(id);
            return View(student);
        }


        [HttpPost]
        public ActionResult Edit(Student model)
        {

            if (ModelState.IsValid)
            {

                var entity = _studentRepository.Find(model.Id);
                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;

                _unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

    }
}