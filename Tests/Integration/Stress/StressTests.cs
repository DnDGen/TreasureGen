using System;
using System.Diagnostics;
using EquipmentGen.Tests.Integration.Common;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress
{
    [TestFixture]
    public abstract class StressTest : IntegrationTest
    {
        private const Int32 ConfidentIterations = 1000000;
        private const Int32 TimeLimitInSeconds = 1;

        private Stopwatch stopwatch;
        private Int32 iterations;
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
            iterations = 0;
        }

        protected void StopTest()
        {
            stopwatch.Reset();
        }

        protected Boolean TestShouldKeepRunning()
        {
            return stopwatch.Elapsed.Seconds < TimeLimitInSeconds && iterations++ < ConfidentIterations;
        }

        protected Int32 GetNewLevel()
        {
            return random.Next(1, 21);
        }

        protected void AssertIterations()
        {
            Assert.That(iterations, Is.GreaterThan(0));
            Assert.Pass("Iterations: {0}", iterations);
        }
    }
}