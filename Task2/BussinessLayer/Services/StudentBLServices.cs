using BussinessLayer.DTOs;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Services
{
    public class StudentBLServices
    {

        public static StudentRepository _StudentRepo = new StudentRepository();



        public StudentBLServices()
        {
          
        }

        public List<StudentListDTO> GetAll()
        {
            var studentEntities =  _StudentRepo.GetAll();
            var students = new List<StudentListDTO>();
            foreach (var Entity in studentEntities)
            {
                students.Add(new StudentListDTO()
                {
                    Id = Entity.Id,
                    Name = Entity.Name,
                    Age = Entity.Age,
                    Address = Entity.Address,
                    Image = Entity.Image,
                }
                );

            }
            return students;
        }

        public StudentDetailsDTO ? GetById(int Id)
        {
           var studentEntity =  _StudentRepo.GetById(Id);
            var stdDTO = new StudentDetailsDTO()
            {
                Id = studentEntity.Id,
                Name = studentEntity.Name,
                Age = studentEntity.Age,
                Address = studentEntity.Address,
                Image = studentEntity.Image,

            };
           return stdDTO;
        }

        
        public void AddStudent(AddStudentDTO stdDTO)
        {
            Student std = new Student()
            {
                Id = _StudentRepo.GetMaximumId() + 1,
                Name = stdDTO.Name,
                Age = stdDTO.Age,
                Address = stdDTO.Address,
                Image = stdDTO.Image,

            };
            _StudentRepo.AddStudent(std);

        }
        public void UpdateStudent(Student updatestd)
        {
            _StudentRepo.UpdateStudent(updatestd);


        }
    }
    
}
