
namespace Coticula.Data.Storage
{
    class FileTaskMemento : IMemento
    {
        private readonly int id;

        private readonly string basePath;

        public FileTaskMemento(int id, string basePath)
        {
            this.id = id;
            this.basePath = basePath;
        }

        private ITask state;
        public ITask State
        {
            get
            {
                state = new TestingTask(basePath, id);
                return state;
            }
        }
    }
}
