using Coticula.Testers;
using NUnit.Framework;
using System;

namespace Coticula.Test.Data
{
    [TestFixture]
    public class VerdictTests
    {
        static object[] AllVerdicts =
                {
                    new object[] { Verdict.Accepted },
                    new object[] { Verdict.InternalError },
                    new object[] { Verdict.MemoryLimit },
                    new object[] { Verdict.RunTimeError },
                    new object[] { Verdict.TimeLimit },
                    new object[] { Verdict.Waiting },
                    new object[] { Verdict.WrongAnswer },
                };

        [Test]
        [TestCaseSource("AllVerdicts")]
        public void TestConcreteVerdict(Verdict verdict)
        {
            Assert.Contains(verdict.ToString(), Enum.GetNames(typeof(Verdict)));
        }

        [Test]
        public void TestCoutOfVerdicts()
        {
            Assert.AreEqual(7, Enum.GetNames(typeof(Verdict)).Length);
        }
    }
}
