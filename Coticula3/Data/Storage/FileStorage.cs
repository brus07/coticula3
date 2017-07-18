
using System.IO;

namespace Coticula.Data.Storage
{
    class FileStorage : IStorage
    {
        private readonly string basePath;

        public FileStorage(string basePath)
        {
            this.basePath = basePath;
        }

        public ITask GetTask(int id)
        {
            string taskPath = Path.Combine(basePath, "Problems", "Problem" + id);
            return (new FileTaskMemento(id, taskPath)).State;
        }
    }
}
