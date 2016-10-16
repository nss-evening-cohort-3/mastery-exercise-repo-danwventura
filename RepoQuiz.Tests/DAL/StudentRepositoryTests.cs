using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RepoQuiz.DAL;

namespace RepoQuiz.Tests.DAL
{
    [TestClass]
    public class StudentRepositoryTests
    {

        [TestMethod]
        public void EnsureCanCreateInstanceOfStudentRepo()
        {
            StudentRepository repo = new StudentRepository();
            Assert.IsNotNull(repo);
        }
    }
}
