using System;
using System.IO;
using NUnit.Framework;
using Coticula.Data.Storage;

namespace Coticula.Internal.Test.Data.Storage
{
    [TestFixture]
    public class FileTaskMementoTests
    {
        private string ProblemsBasePath;

        [SetUp]
        public void Init()
        {
            string problemsBasePath = Path.Combine(Environment.CurrentDirectory, "..", "..", "..", "..");
            ProblemsBasePath = Path.Combine(problemsBasePath, "TestData", "Problems");
        }

        [Test]
        public void LoadTaskWithIncorrectBasePath()
        {
            var fileTaskMemento = new FileTaskMemento(1, "");
            Assert.Throws<ArgumentException>(() => { var res = fileTaskMemento.State; });
        }

        [Test]
        public void LoadTaskId1()
        {
            const int id = 1;
            var fileTaskMemento = new FileTaskMemento(id, Path.Combine(ProblemsBasePath,"Problem"+id));
            var task = fileTaskMemento.State;
            Assert.AreEqual(id, task.Id);
            Assert.Greater(task.Tests.Count, 1);
        }
    }
}
