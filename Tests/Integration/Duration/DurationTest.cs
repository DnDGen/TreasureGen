using System.Diagnostics;
using EquipmentGen.Tests.Integration.Common;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Duration
{
    [TestFixture]
    public abstract class DurationTest : IntegrationTest
    {
        [Inject]
        public Stopwatch Stopwatch { get; set; }

        protected void StartTest()
        {
            Stopwatch.Start();
        }

        protected void AssertDuration()
        {
            Assert.Pass("Duration: {0}ms", Stopwatch.ElapsedMilliseconds);
        }

        protected void StopTest()
        {
            Stopwatch.Reset();
        }
    }
}