using System;
using System.Diagnostics;
using EquipmentGen.Tests.Integration.Common;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Duration
{
    [TestFixture]
    public abstract class DurationTest : IntegrationTest
    {
        private Stopwatch stopwatch;
        private Random random;

        [SetUp]
        public void Setup()
        {
            stopwatch = new Stopwatch();
            random = new Random();
        }

        protected void StartTest()
        {
            stopwatch.Start();
        }

        protected void AssertDuration()
        {
            Assert.Pass("Duration: {0}ms", stopwatch.ElapsedMilliseconds);
        }

        protected void StopTest()
        {
            stopwatch.Reset();
        }

        protected Int32 GetNewLevel()
        {
            return random.Next(1, 21);
        }
    }
}