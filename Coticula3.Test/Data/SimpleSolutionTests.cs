using Coticula.Data;
using NUnit.Framework;

namespace Coticula.Test.Data
{
    [TestFixture]
    public class SimpleSolutionTests
    {
        [Test]
        public void TestGetTaskIdProperty()
        {
            const int id = 123;
            SimpleSolution solution = new SimpleSolution
            {
                TaskId = id
            };
            Assert.AreEqual(id, solution.TaskId);
        }
        [Test]
        public void TestGetSolutionProperty()
        {
            const string value = "begin\nend.";
            SimpleSolution solution = new SimpleSolution
            {
                Solution = value
            };
            Assert.AreEqual(value, solution.Solution);
        }

        [Test]
        public void TestGetLanguageProperty()
        {
            const Language language = Language.CSharp;
            SimpleSolution solution = new SimpleSolution
            {
                Language = language
            };
            Assert.AreEqual(language, solution.Language);

        }
    }
}
