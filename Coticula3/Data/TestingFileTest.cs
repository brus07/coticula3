
namespace Coticula.Data
{
    class TestingFileTest : ITest
    {
        public TestingFileTest(int id, string inputFilePath, string outputFilePath)
        {
            Id = id;
            InputFilePath = inputFilePath;
            OutputFilePath = outputFilePath;
        }

        public int Id
        {
            get;
            private set;
        }

        public string InputFilePath
        {
            get;
            private set;
        }

        public string OutputFilePath
        {
            get;
            private set;
        }
    }
}
