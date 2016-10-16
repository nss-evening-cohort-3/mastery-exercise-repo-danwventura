using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RepoQuiz.Models;

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
