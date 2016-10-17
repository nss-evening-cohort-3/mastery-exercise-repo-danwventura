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

        [TestMethod]
        public void EnsureStudentPropertiesAreNotNull()
        {
            Student test_student = new Student();
            NameGenerator new_generator = new NameGenerator();
            new_generator.GenerateStudentData();

            Assert.IsNotNull(test_student.FirstName);
            Assert.IsNotNull(test_student.LastName);
            Assert.IsNotNull(test_student.Major);
        }
    }
}
