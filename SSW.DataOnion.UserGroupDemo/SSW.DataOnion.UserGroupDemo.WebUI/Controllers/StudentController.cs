using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SSW.Data.Interfaces;
using SSW.DataOnion.UserGroupDemo.DataInterfaces.Repositories;
using SSW.DataOnion.UserGroupDemo.Domain;
using SSW.DataOnion.UserGroupDemo.WebUI.ViewModels;

namespace SSW.DataOnion.UserGroupDemo.WebUI.Controllers
{

   

    public class StudentController : Controller
    {

        private readonly IStudentVmMapper _studentVmMapper;
        private readonly IUnitOfWork _unitOfWork;

        public StudentController(IUnitOfWork unitOfWork, 
            IStudentVmMapper studentVmMapper)
        {
            _unitOfWork = unitOfWork;
            _studentVmMapper = studentVmMapper;
        }

        // GET: Default
        public ActionResult Index()
        {
            return View(_studentVmMapper.GetList());
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(_studentVmMapper.GetViewModel(id));
        }

        [HttpPost]
        public ActionResult Edit(StudentVm model)
        {
            if (ModelState.IsValid)
            {
                _studentVmMapper.SaveViewModel(model);
                _unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

    }
}