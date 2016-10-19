using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RepoQuiz.DAL;
using RepoQuiz.Models;
using Moq;

namespace RepoQuiz.Tests.DAL
{
    [TestClass]
    public class NameGeneratorTests
    {
        

        [TestMethod]
        public void EnsureCanCreateInstanceOfNameGeneratorClass()
        {
            NameGenerator new_generator = new NameGenerator();
            Assert.IsNotNull(new_generator);
        }

        [TestMethod]
        public void EnsureCanCreateRandomStudents()
        {
            NameGenerator generator1 = new NameGenerator();
            NameGenerator generator2 = new NameGenerator();

            Student new_student1 = generator1.GenerateStudentData();
            Student new_student2 = generator2.GenerateStudentData();

            Assert.AreNotEqual(new_student1,new_student2);
        }

        [TestMethod]
        public void EnsureRandomStudentPropertiesAreNotNull()
        {
            NameGenerator generator1 = new NameGenerator();
            NameGenerator generator2 = new NameGenerator();

            Student new_student1 = generator1.GenerateStudentData();
            Student new_student2 = generator2.GenerateStudentData();

            Assert.IsNotNull(new_student1.FirstName);
            Assert.IsNotNull(new_student1.LastName);
            Assert.IsNotNull(new_student1.Major);

            Assert.IsNotNull(new_student2.FirstName);
            Assert.IsNotNull(new_student2.LastName);
            Assert.IsNotNull(new_student2.Major);
        }
        
    }
}
