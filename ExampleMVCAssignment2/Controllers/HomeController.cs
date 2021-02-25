using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ExampleMVCAssignment2.Models;
using Microsoft.Extensions.Logging;



namespace ExampleMVCAssignment2.Controllers
{
    public class HomeController : Controller
    {
       

        private readonly IStudentRepository _studentRepository;
        private readonly object _listStudent;

        public HomeController(IStudentRepository studentRepository)
        {
            
            _studentRepository = studentRepository;
        }


        public ViewResult Index()
        {
            var studentDetails = _studentRepository.GetAllStudent();
            return View(studentDetails);
        }
        public ViewResult Details(int? Id)
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Student = _studentRepository.GetStudent(Id ?? 1),
                
            };
            //Student studentDetails =  _studentRepository.GetStudent(101);
            return View(homeDetailsViewModel);
        }


        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if(ModelState.IsValid)
            {
                Student newStudent = _studentRepository.Add(student);
                return RedirectToAction("details", new { id = student.StudentId });
            }
            return View();
           
        }
        
        [HttpGet]
        public IActionResult Delete(int StudentId)
        {
            var student = _studentRepository.GetStudent(StudentId);
            
            if (student == null)
            {
                return RedirectToAction("NotFound");
            }
            
            else
            {
                return View();
            }
            
        }

        [HttpPost]
        public IActionResult Delete(Student student)
        {
            student = _studentRepository.Delete(student.StudentId);

            if (student == null)
            {
                return RedirectToAction("NotFound");
            }
            else
            {
                return View("index");
            }

           
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
