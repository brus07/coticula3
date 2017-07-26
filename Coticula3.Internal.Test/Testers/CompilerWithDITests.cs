using Coticula.Data;
using Coticula.Testers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using Protex;

namespace Coticula.Internal.Test.Testers
{
    [TestFixture]
    public class CompilerWithDITests
    {
        [Test]
        [Explicit]
        public void TestCompilerWith_WithDIAndLogging()
        {
            var runnerMock = new Mock<IRunner>();

            var serviceProvider = new ServiceCollection()
               .AddLogging()
               .AddSingleton(runnerMock.Object)
               .AddTransient<ICompiler, Compiler>()
               .BuildServiceProvider();

            //configure console logging
            serviceProvider
                .GetService<ILoggerFactory>()
                .AddConsole(LogLevel.Debug);

            ICompiler compiler = serviceProvider.GetService<ICompiler>();

            ISolution solution = new SimpleSolution()
            {
                TaskId = 123,
                Solution = @"
using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(""Hello World!"");
        }
    }
}

",
                Language = Language.CSharp
            };

            var result = compiler.Run(solution);
        }
    }
}
