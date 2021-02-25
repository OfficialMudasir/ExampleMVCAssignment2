using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleMVCAssignment2.Models
{
    public interface IStudentRepository
    {
        Student GetStudent(int StudentId);
        IEnumerable<Student> GetAllStudent();
        Student Add(Student student);
        Student Delete(int Id);
        
    }
}
