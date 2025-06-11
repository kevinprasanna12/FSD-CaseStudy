using StudentDAL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDAL.Repository
{
    public class InMemoryStudentRepository : IStudentRepository
    {
        private readonly List<Student> _students = new List<Student>();

        public List<Student> GetAll()
        {
            return _students.ToList();
        }

        public Student GetByRollNo(int rollNo)
        {
            return _students.FirstOrDefault(s => s.RollNo == rollNo);
        }

        public Student GetByName(string name)
        {
            return _students.FirstOrDefault(s => s.Name == name);
        }

        public void Add(Student student)
        {
            _students.Add(student);
        }

        public void Update(Student student)
        {
            var existing = _students.FirstOrDefault(s => s.RollNo == student.RollNo);
            if (existing != null)
            {
                existing.Name = student.Name;
                existing.Email = student.Email;
            }
        }

        public void Delete(int rollNo)
        {
            var student = _students.FirstOrDefault(s => s.RollNo == rollNo);
            if (student != null)
            {
                _students.Remove(student);
            }
        }
    }
}
