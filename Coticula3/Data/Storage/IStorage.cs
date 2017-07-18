
namespace Coticula.Data.Storage
{
    internal interface IStorage
    {
        ITask GetTask(int id);
    }
}
