using System.Collections.Generic;

namespace Coticula.Data
{
    internal interface ITask
    {
        int Id { get; }

        List<ITest> Tests { get; }
    }
}
