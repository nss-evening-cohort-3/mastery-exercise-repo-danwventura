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
    }
}
