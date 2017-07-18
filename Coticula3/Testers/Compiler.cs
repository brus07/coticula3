using System;
using Coticula.Data;
using Protex;

namespace Coticula.Testers
{
    internal class Compiler
    {
        private IRunner _runner;

        public Compiler(IRunner runner)
        {
            _runner = runner;
        }

        public ITestingResult Run(ISolution solution)
        {
            throw new NotImplementedException();
        }
    }
}
