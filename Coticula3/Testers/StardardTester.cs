using System;
using Coticula.Data;
using Coticula.Data.Storage;
using Protex;

namespace Coticula.Testers
{
    internal class StardardTester: ITester
    {
        private readonly IRunner _runner;

        private readonly IStorage _storage;
        IStorage Storage
        {
            get
            {
                return _storage;
            }
        }

        public StardardTester(IRunner runner, IStorage storage)
        {
            _runner = runner;
            _storage = storage;
        }

        public ITestingResult Run(ISolution solution)
        {
            StardardTestingResult result = new StardardTestingResult();
            result.Verdict = Verdict.Waiting;

            try
            {
                ITask task = Storage.GetTask(solution.TaskId);

                ITestingResult compileResult = CompileSolution(solution);
                if (compileResult.Verdict != Verdict.Accepted)
                    return compileResult;

                result.Verdict = compileResult.Verdict;

                for (int i=0;i< task.Tests.Count; i++)
                {
                    ITestingResult testResult = RunSolutionOnTest(solution, task.Tests[i]);
                    if (testResult.Verdict != Verdict.Accepted)
                    {
                        return testResult;
                    }
                    result.Verdict = testResult.Verdict;
                }
            }
            catch (ArgumentException)
            {
                result.Verdict = Verdict.InternalError;
            }

            return result;
        }

        private ITestingResult CompileSolution(ISolution solution)
        {
            Compiler compiler = new Compiler(_runner);
            return compiler.Run(solution);
        }

        private ITestingResult RunSolutionOnTest(ISolution solution, ITest test)
        {
            throw new NotImplementedException();
        }
    }
}
