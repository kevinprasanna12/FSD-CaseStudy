using StudentDAL.BuisnessLogic;
using StudentDAL.Domain;
using StudentDAL.Repository;
using System.Collections.Generic;
using Xunit;

namespace StudentTests
{
    public class StudentServiceTests
    {
        private readonly StudentService _service;
        private readonly InMemoryStudentRepository _repository;

        public StudentServiceTests()
        {
            _repository = new InMemoryStudentRepository();
            _service = new StudentService(_repository);
        }

        [Fact]
        public void AddStudent_ShouldAddSuccessfully()
        {
            var student = new Student { RollNo = 1, Name = "Kevin", Email = "kevin@email.com" };
            _service.AddStudent(student);

            var result = _service.GetStudentByRollNo(1);
            Assert.NotNull(result);
            Assert.Equal("Kevin", result.Name);
        }

        [Fact]
        public void UpdateStudent_ShouldUpdateSuccessfully()
        {
            var student = new Student { RollNo = 2, Name = "John", Email = "john@email.com" };
            _service.AddStudent(student);

            student.Name = "Johnny";
            _service.UpdateStudent(student);

            var updated = _service.GetStudentByRollNo(2);
            Assert.Equal("Johnny", updated.Name);
        }

        [Fact]
        public void DeleteStudent_ShouldRemoveSuccessfully()
        {
            var student = new Student { RollNo = 3, Name = "Alice", Email = "alice@email.com" };
            _service.AddStudent(student);

            _service.DeleteStudent(3);
            var deleted = _service.GetStudentByRollNo(3);

            Assert.Null(deleted);
        }

        [Fact]
        public void GetStudentByName_ShouldReturnCorrectStudent()
        {
            var student = new Student { RollNo = 4, Name = "Sam", Email = "sam@email.com" };
            _service.AddStudent(student);

            var result = _service.GetStudentByName("Sam");
            Assert.NotNull(result);
            Assert.Equal(4, result.RollNo);
        }

        [Fact]
        public void GetAllStudents_ShouldReturnAllStudents()
        {
            _service.AddStudent(new Student { RollNo = 5, Name = "Kiran", Email = "kiran@email.com" });
            _service.AddStudent(new Student { RollNo = 6, Name = "Arun", Email = "arun@email.com" });

            var all = _service.GetAllStudents();
            Assert.Equal(2, all.Count);
        }
    }
}