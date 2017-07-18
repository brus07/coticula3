using System;
using System.IO;
using Coticula.Data;
using NUnit.Framework;

namespace Coticula.Internal.Test.Data
{
    [TestFixture]
    public class TestingTaskTests
    {
        private string ProblemsBasePath;

        static object[] IdsCases =
                {
                    new object[] { 1 },
                    new object[] { 123 },
                    new object[] { 54321 },
                    new object[] { -1 },
                };

        [SetUp]
        public void Init()
        {
            string problemsBasePath = Path.Combine(Environment.CurrentDirectory, "..", "..", "..", "..");
            ProblemsBasePath = Path.Combine(problemsBasePath, "TestData", "Problems");
        }

        [Test]
        [TestCaseSource("IdsCases")]
        public void TestGetIdProperty(int id)
        {
            string problemsBasePath = Path.Combine(ProblemsBasePath, "Problem1");
            TestingTask testingTask = new TestingTask(problemsBasePath, id);
            Assert.AreEqual(id, testingTask.Id);
        }

        [Test]
        public void TestLoadProblem()
        {
            int id = 1;
            string problemsBasePath = Path.Combine(ProblemsBasePath, "Problem"+id);

            TestingTask testingTask = new TestingTask(problemsBasePath, id);
            Assert.AreEqual(id, testingTask.Id);
        }

        [Test]
        public void TestGetTestsProperty()
        {
            int id = 1;
            string problemsBasePath = Path.Combine(ProblemsBasePath, "Problem" + id);
            TestingTask testingTask = new TestingTask(problemsBasePath, id);
            Assert.AreEqual(id, testingTask.Id);
            Assert.AreEqual(4, testingTask.Tests.Count);
            for (int i=0; i<testingTask.Tests.Count; i++)
            {
                Assert.IsNotNull(testingTask.Tests[i].InputFilePath);
                Assert.IsNotEmpty(testingTask.Tests[i].InputFilePath);

                Assert.IsNotNull(testingTask.Tests[i].OutputFilePath);
                Assert.IsNotEmpty(testingTask.Tests[i].OutputFilePath);
            }
        }


        static object[] IncorrectIdsCases =
                {
                    new object[] { -1 },
                    new object[] { 123 },
                    new object[] { 54321 },
                    new object[] { 0 },
                    new object[] { 123456789 },
                };

        [Test]
        [TestCaseSource("IncorrectIdsCases")]
        public void TestLoadProblem(int id)
        {
            string problemsBasePath = Path.Combine(ProblemsBasePath, "Problem" + id);

            Assert.Throws<ArgumentException>(() => new TestingTask(problemsBasePath, id));
        }
    }
}
