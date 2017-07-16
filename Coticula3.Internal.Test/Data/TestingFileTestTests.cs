using Coticula.Data;
using NUnit.Framework;
using System.Collections;

namespace Coticula.Internal.Test.Data
{
    [TestFixture]
    public class TestingFileTestTests
    {
        [Test, TestCaseSource(typeof(MyFactoryClass), "TestCases")]
        public void TestTestingFileTestCreatingAndProperties(int id, string inputFilePath, string outputFilePath)
        {

            ITest test = new TestingFileTest(id, inputFilePath, outputFilePath);
            Assert.AreEqual(id, test.Id);
            Assert.AreEqual(inputFilePath, test.InputFilePath);
            Assert.AreEqual(outputFilePath, test.OutputFilePath);
        }

        public class MyFactoryClass
        {
            public static IEnumerable TestCases
            {
                get
                {
                    yield return new TestCaseData(1, "", "");
                    yield return new TestCaseData(2, "input", "output");
                    yield return new TestCaseData(3, "inout", "inout");
                    yield return new TestCaseData(4, null, "output");
                    yield return new TestCaseData(5, "input", null);
                    yield return new TestCaseData(16, @"c:\Users\Public\Documents\coticula3\TestData\Problems\Problem1\test1\in.txt", @"c:\Users\Public\Documents\coticula3\TestData\Problems\Problem1\test1\out.txt");
                    yield return new TestCaseData(17, @"TestData\Problems\Problem1\test1\in.txt", @"TestData\Problems\Problem1\test1\out.txt");
                    yield return new TestCaseData(18, @"/usr/bin/coticula3/TestData/Problems/Problem7/test4/in.txt", @"/usr/bin/coticula3/TestData/Problems/Problem7/test4/out.txt");
                    yield return new TestCaseData(19, @"TestData/Problems/Problem7/test4/in.txt", @"TestData/Problems/Problem7/test4/out.txt");
                }
            }
        }
    }
}
