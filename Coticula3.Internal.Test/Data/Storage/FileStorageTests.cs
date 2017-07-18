using System;
using System.IO;
using NUnit.Framework;
using Coticula.Data.Storage;
using Coticula.Data;

namespace Coticula.Internal.Test.Data.Storage
{
    [TestFixture]
    public class FileStorageTests
    {
        private string TestDataBasePath;

        [SetUp]
        public void Init()
        {
            string problemsBasePath = Path.Combine(Environment.CurrentDirectory, "..", "..", "..", "..");
            TestDataBasePath = Path.Combine(problemsBasePath, "TestData");
        }

        [Test]
        public void LoadTaskByStorage()
        {
            const int id = 1;
            IStorage storage = new FileStorage(TestDataBasePath);
            ITask task = storage.GetTask(id);
            Assert.AreEqual(id, task.Id);
            Assert.Greater(task.Tests.Count, 1);
        }

        [Test]
        public void TestIncorrectTaskId()
        {
            const int id = 23;
            IStorage storage = new FileStorage(TestDataBasePath);
            Assert.Throws<ArgumentException>(() => { ITask task = storage.GetTask(id); });
        }
    }
}
