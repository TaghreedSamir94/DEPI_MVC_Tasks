using BussinessLayer.DTOs;
using BussinessLayer.Services;
using DataAccessLayer.Entities;
using DataAccessLayer.VMs;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.ActionRequests;
using PresentationLayer.Models;
using PresentationLayer.VMs;

namespace PresentationLayer.Controllers
{
    public class StudentController : Controller
    {
        static StudentBLServices _stdservecies = new StudentBLServices();

        [HttpGet]
        public IActionResult Index()
        {
          
            List<StudentListDTO> studentListDTOs = _stdservecies.GetAll();
            var students = new List<StudentListVMs>();
            foreach (var Entity in studentListDTOs)
            {
                students.Add(new StudentListVMs()
                {
                    Id = Entity.Id,
                    Name = Entity.Name,
                    Age = Entity.Age,
                    Address = Entity.Address,
                    Image = Entity.Image,
                }
                );

            }

            return View("AllStudentsList", students);
        }


        [HttpGet]
        public IActionResult Details(int Id)
        {
            
            StudentDetailsDTO? std1DTO = _stdservecies.GetById(Id);
            var stdVM = new StudentDetailsVMs()
            {
                Id = std1DTO.Id,
                Name = std1DTO.Name,
                Age = std1DTO.Age,
                Address = std1DTO.Address,
                Image = std1DTO.Image,

            };
            //send view
            return View("details", stdVM);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateStudentActionRequest std, IFormFile imageFile)
        {
            if (ModelState.IsValid)
            {
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;
                if (imageFile != null && imageFile.Length > 0)
                {
                    string path = Path.Combine(@".\wwwroot\images\", uniqueFileName);
                    using (var filestream = new FileStream(path, FileMode.Create))
                    {
                        imageFile.CopyTo(filestream);
                    }
                }
                AddStudentDTO stdDTO = new AddStudentDTO()
                {
                    Name = std.Name,
                    Age = std.Age,
                    Address = std.Address,
                    Image = uniqueFileName,


                };
                _stdservecies.AddStudent(stdDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(std);
        }
    }
}
