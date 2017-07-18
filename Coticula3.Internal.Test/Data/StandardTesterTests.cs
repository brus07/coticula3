using Coticula.Data;
using Coticula.Data.Storage;
using Coticula.Testers;
using Moq;
using NUnit.Framework;
using Protex;

namespace Coticula.Internal.Test.Data
{
    [TestFixture]
    public class StandardTesterTests
    {
        [Test]
        [Explicit("Waiting for implementing Run method in StardardTester.")]
        public void RunTesterTest()
        {
            var runnerMock = new Mock<IRunner>();
            var storageMock = new Mock<IStorage>();

            ITester tester = new StardardTester(runnerMock.Object, storageMock.Object);

            ISolution solution = new SimpleSolution()
            {
                TaskId = 123,
                Solution = "begin \n end.",
                Language = Language.CSharp
            };

            var result = tester.Run(solution);
        }
    }
}
