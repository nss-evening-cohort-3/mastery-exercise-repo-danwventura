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
    }
}
