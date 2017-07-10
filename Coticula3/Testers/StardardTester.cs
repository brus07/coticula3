using Coticula.Data;
using Protex;

namespace Coticula.Testers
{
    internal class StardardTester
    {
        private readonly IRunner _runner;

        public StardardTester(IRunner runner)
        {
            _runner = runner;
        }

        public ITestingResult Run(ISolution solution)
        {
            throw new System.NotImplementedException();
        }
    }
}
