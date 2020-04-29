using AutoFixture;
using Moq;
using NUnit.Framework;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace ServiceBus.Function.App.Services.Tests
{

    [ExcludeFromCodeCoverage]
    [TestFixture]
    public class TestBase
    {
        protected MockRepository _mockRepository { get; private set; }

        private Stopwatch _stopwatch;

        protected Fixture _fixture { get; private set; }

        [SetUp]
        public void TestInitializer()
        {
            _mockRepository = new MockRepository(MockBehavior.Strict);
            _stopwatch = Stopwatch.StartNew();
            _fixture = new Fixture();
        }

        [TearDown]
        public void TestCleanup()
        {
            _mockRepository.VerifyAll();
            _stopwatch.Stop();
            Trace.WriteLine("***********************************************************");
            Trace.WriteLine($"Elapsed Time for Test(Milliseconds) {_stopwatch.ElapsedMilliseconds}");
            Trace.WriteLine("***********************************************************");
        }
    }
}
