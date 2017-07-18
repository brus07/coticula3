﻿using Coticula.Data;
using Coticula.Testers;
using Protex;
using Moq;
using NUnit.Framework;

namespace Coticula.Internal.Test.Testers
{
    [TestFixture]
    public class CompilerTests
    {
        [Test]
        [Explicit]
        public void TestCompiler()
        {
            var runnerMock = new Mock<IRunner>();
            Compiler compiler = new Compiler(runnerMock.Object);

            ISolution solution = new SimpleSolution()
            {
                TaskId = 123,
                Solution = @"
using System;

public class Swap
{
    private static void Main()
    {
        string[] tokens = Console.ReadLine().Split();
        Console.WriteLine(""{ 0 } { 1 }"", int.Parse(tokens[1]), int.Parse(tokens[0]));
    }
}
",
                Language = Language.CSharp
            };

            var result = compiler.Run(solution);
        }
    }
}
