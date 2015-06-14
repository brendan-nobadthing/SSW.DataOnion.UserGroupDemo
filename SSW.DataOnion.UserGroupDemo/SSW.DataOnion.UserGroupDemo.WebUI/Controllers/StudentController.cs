using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SSW.DataOnion.UserGroupDemo.DataInterfaces.Repositories;

namespace SSW.DataOnion.UserGroupDemo.WebUI.Controllers
{

   

    public class StudentController : Controller
    {

        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        // GET: Default
        public ActionResult Index()
        {
            return View(_studentRepository.Get());
        }
    }
}