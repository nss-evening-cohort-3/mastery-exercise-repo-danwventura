using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RepoQuiz.DAL;
using Moq;
using System.Data.Entity;
using RepoQuiz.Models;
using System.Collections.Generic;
using System.Linq;

namespace RepoQuiz.Tests.DAL
{
    [TestClass]
    public class StudentRepositoryTests
    {
        Mock<StudentContext> mock_context { get; set; }
        Mock<DbSet<Student>> mock_student_table { get; set; }
        List<Student> student_list { get; set; }

        StudentRepository repo { get; set; }

        public void ConnectMocksToDatastore()
        {
            var queryable_student_list = student_list.AsQueryable();

            //      FOUR Behaviors of an IQueryable
            mock_student_table.As<IQueryable<Student>>().Setup(mock => mock.Provider).Returns(queryable_student_list.Provider);
            mock_student_table.As<IQueryable<Student>>().Setup(mock => mock.Expression).Returns(queryable_student_list.Expression);
            mock_student_table.As<IQueryable<Student>>().Setup(mock => mock.ElementType).Returns(queryable_student_list.ElementType);
            mock_student_table.As<IQueryable<Student>>().Setup(mock => mock.GetEnumerator()).Returns(queryable_student_list.GetEnumerator);

            //      Have Students property return our queryable list AKA fake db table
            mock_context.Setup(a => a.Students).Returns(mock_student_table.Object);

            //      Callbacks
            mock_student_table.Setup(c => c.Add(It.IsAny<Student>())).Callback((Student a) => student_list.Add(a));

        }

        [TestInitialize]
        public void Initiliaze()
        {
            mock_context = new Mock<StudentContext>();
            mock_student_table = new Mock<DbSet<Student>>();
            student_list = new List<Student>();
            repo = new StudentRepository(mock_context.Object);
            ConnectMocksToDatastore();
        }

        [TestCleanup]
        public void TearDown()
        {
            repo = null;
        }

        [TestMethod]
        public void EnsureCanCreateInstanceOfStudentRepo()
        {
            StudentRepository repo = new StudentRepository();
            Assert.IsNotNull(repo);
        }

        [TestMethod]
        public void EnsureRepoHasContext()
        {
            StudentRepository repo = new StudentRepository();
            StudentContext Context = new StudentContext();
            Assert.IsInstanceOfType(Context, typeof(StudentContext));
        }

        [TestMethod]
        public void EnsureThereAreNoStudents()
        {
            List<Student> all_students = repo.GetAllStudents();
            int expected_count = 0;
            int all_students_count = all_students.Count();
            Assert.AreEqual(expected_count, all_students_count);
        }

        [TestMethod]
        public void EnsureCanAddNewStudent()
        {
            NameGenerator generator1 = new NameGenerator();
            Student new_student1 = generator1.GenerateStudentData();
            Student new_student2 = generator1.GenerateStudentData();

            repo.AddNewStudent(new_student1);
            repo.AddNewStudent(new_student2);

            List<Student> all_students = repo.GetAllStudents();
            int expected_student_count = 2;
            int all_students_count = all_students.Count;

            Assert.AreNotEqual(new_student1, new_student2);
            Assert.AreEqual(expected_student_count, all_students_count);

        }

        [TestMethod]
        public void EnsureCanAddNewStudentWithArgs()
        {
            NameGenerator generator1 = new NameGenerator();
            Student new_student = new Student {StudentID = 1, FirstName = "Sam", LastName="Ventura", Major = "Hospitality" };

            repo.AddNewStudent(new_student);
            List<Student> all_students = repo.GetAllStudents();

            int expected_student_count = 1;
            int actual_student_count = all_students.Count;

            Assert.AreEqual(expected_student_count, actual_student_count);

        }


        [TestMethod]
        public void EnsureCanGetStudentById()
        {
            NameGenerator generator1 = new NameGenerator();
            // Create student with ID properties (manually)
            Student student1 = new Student {StudentID = 0, FirstName = "Mary", LastName = "Gallagher", Major = "Physics" };
            Student student2 = new Student {StudentID = 1, FirstName = "Austin", LastName= "Xiao", Major="Linguistics" };



            repo.AddNewStudent(student1);
            repo.AddNewStudent(student2);

            int student_id = 1;
            int expected_student_id = 1;
            Student actual_student = repo.FindStudentById(student_id);
            int actual_student_id = actual_student.StudentID;

            Assert.AreEqual(expected_student_id, actual_student_id);

        }
    }
}
