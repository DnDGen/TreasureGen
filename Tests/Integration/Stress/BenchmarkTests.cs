using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress
{
    [TestFixture]
    public class BenchmarkTests : StressTests
    {
        [SetUp]
        public void Setup()
        {
            StartTest();
        }

        [TearDown]
        public void TearDown()
        {
            StopTest();
        }

        [Test]
        public void MaxSpeed()
        {
            while (TestShouldKeepRunning()) { }
            AssertIterations();
        }
    }
}