using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class StudentRepository
    {
        private List<Student> students = new List<Student>();

        public StudentRepository() 
        {

            students.AddRange(
             [
                new Student(){Id = 1, Name = "Sam", Age = 20, Address = "NewYork city", Image = "1.jfif" },
                    new Student(){Id = 2, Name = "Clover", Age = 18, Address = "Seoul city", Image = "2.jfif" },
                    new Student(){Id = 3, Name = "Blossom", Age = 19, Address = "Tokio city", Image = "3.jfif" },
                    new Student(){Id = 4, Name = "Buttercup", Age = 21, Address = "FlowerGarden city", Image = "4.jfif" }
                ]



            );
        }

        public List<Student> GetAll()
        {
            return students;
        }

        public int GetMaximumId()
        {
            return students.Max( student => student.Id );
        }
        public Student GetById(int Id)
        {
            Student? std = students.FirstOrDefault(std => std.Id == Id);

            return std;
        }

        public void AddStudent(Student std)
        { 
            students.Add(std);
        
        }
        public void UpdateStudent(Student updatestd)
        {
            Student? std = GetById(updatestd.Id);
            if(std != null)
            {
                std.Name = updatestd.Name;  
                std.Age = updatestd.Age;
                std.Address = updatestd.Address;
                std.Image = updatestd.Image;
            }


        }
    }
}
