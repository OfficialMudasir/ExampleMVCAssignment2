using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleMVCAssignment2.Models
{
    public class MockStudentRepository : IStudentRepository
    {
        private List<Student> _listStudent;

        public MockStudentRepository()
        {
            _listStudent = new List<Student>()
            {
               new Student() { StudentId = 101, Name = "James", Branch = Branch.CSE, Gender = Gender.Male, Address = "A1-2018", Email = "James@g.com" },
               new Student() { StudentId = 102, Name = "Priyanka", Branch = Branch.ETC, Gender = Gender.Female, Address = "A1-2019", Email = "Priyanka@g.com" },
               new Student() { StudentId = 103, Name = "David", Branch = Branch.CSE, Gender = Gender.Male, Address = "A1-2020", Email = "David@g.com" },
               

            };
        }

        public Student Add(Student student)
        {
            student.StudentId = _listStudent.Max(std => std.StudentId) + 1;
            _listStudent.Add(student);
            return student;
        }

        public Student Delete(int Id)
        {
            Student student = _listStudent.FirstOrDefault(std => std.StudentId == Id);
            if(student != null)
            {
                _listStudent.Remove(student);
            }
            return student;
        }

        public Student GetStudent(int StudentId)
        {
            return _listStudent.FirstOrDefault(std => std.StudentId == StudentId);
        }


        IEnumerable<Student> IStudentRepository.GetAllStudent()
        {
            return _listStudent;
           
        }
    }
}
