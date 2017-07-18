using Coticula.Data;

namespace Coticula.Testers
{
    internal interface ITester
    {
        ITestingResult Run(ISolution solution);
    }
}