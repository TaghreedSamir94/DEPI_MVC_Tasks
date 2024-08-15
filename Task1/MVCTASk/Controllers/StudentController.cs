using Microsoft.AspNetCore.Mvc;
using MVCTASk.Models;

namespace MVCTASk.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            //ask model
            StudentBL studentBL = new StudentBL();
            List<Student> studentList = studentBL.GetAll();
            //send view
            return View("AllStudentsList", studentList);
        }


        public IActionResult Details(int Id)
        {
            //ask model 
            StudentBL studentBL = new StudentBL();
            Student? std1 = studentBL.GetById(Id);
            //send view
            return View("details", std1);
        }
    }
}
