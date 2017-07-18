
namespace Coticula.Data.Storage
{
    interface IMemento
    {
        ITask State { get; }
    }
}
