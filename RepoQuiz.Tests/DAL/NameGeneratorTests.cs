using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RepoQuiz.DAL;

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
    }
}
