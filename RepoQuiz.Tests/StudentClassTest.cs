using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RepoQuiz.Models;
using RepoQuiz.DAL;

namespace RepoQuiz.Tests
{
    [TestClass]
    public class StudentClassTest
    {


        [TestMethod]
        public void EnsureCanCreateInstanceOfStudentClass()
        {
            Student this_student = new Student();
            Assert.IsNotNull(this_student);
        }


    }
}
