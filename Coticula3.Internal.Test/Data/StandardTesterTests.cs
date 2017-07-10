using Coticula.Data;
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
        [Ignore("Waiting for implementing Run method in StardardTester.")]
        public void RunTesterTest()
        {
            var runnerMock = new Mock<IRunner>();
            StardardTester tester = new StardardTester(runnerMock.Object);

            SimpleSolution solution = new SimpleSolution()
            {
                TaskId = 123,
                Solution = "begin \n end.",
                Language = Language.CSharp
            };

            var result = tester.Run(solution);
        }
    }
}
