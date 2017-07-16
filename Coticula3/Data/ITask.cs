using System.Collections.Generic;

namespace Coticula.Data
{
    public interface ITask
    {
        int Id { get; }

        List<ITest> Tests { get; }
    }
}
