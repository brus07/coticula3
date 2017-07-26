using System;
using Coticula.Data;
using Protex;
using Microsoft.Extensions.Logging;

namespace Coticula.Testers
{
    interface ICompiler
    {
        ITestingResult Run(ISolution solution);
    }

    internal class Compiler: ICompiler
    {
        private IRunner _runner;
        private readonly ILogger<Compiler> _logger;

        public Compiler(IRunner runner)
        {
            _runner = runner;
        }

        public Compiler(IRunner runner, ILoggerFactory loggerFactory)
        {
            _runner = runner;
            _logger = loggerFactory.CreateLogger<Compiler>();
        }

        public ITestingResult Run(ISolution solution)
        {
            throw new NotImplementedException();
        }
    }
}
