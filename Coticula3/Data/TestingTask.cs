using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Coticula.Data
{
    class TestingTask : ITask
    {
        public int Id { get; internal set; }

        public List<ITest> Tests
        {
            get;
            private set;
        }

        public TestingTask(string basePath, int id)
        {
            Id = id;

            if (!Directory.Exists(basePath))
                throw new ArgumentException("Incorrect basePath. Folder does not exist", "basePath");

            Tests = new List<ITest>();
            foreach (var testDir in Directory.EnumerateDirectories(basePath, "test*"))
            {
                if (!Directory.Exists(testDir))
                    continue;

                string inputFile = Path.Combine(testDir, "in.txt");
                string outputFile = Path.Combine(testDir, "out.txt");

                if (!File.Exists(inputFile))
                    continue;
                if (!File.Exists(outputFile))
                    continue;

                var matches = Regex.Matches(testDir, "test([0-9]+)");

                int testId = -1;
                foreach (Match match in matches)
                {
                    if (match.Groups.Count > 0)
                    {
                        string testIdFromMatch = match.Groups[1].Value;
                        if (!Int32.TryParse(testIdFromMatch, out testId))
                            testId = -1;
                    }
                }
                if (testId == -1)
                    continue;

                Tests.Add(new TestingFileTest(testId, inputFile, outputFile));
            }
        }
    }
}
