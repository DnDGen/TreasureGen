using EventGen;
using Ninject;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using TreasureGen.Items;

namespace TreasureGen.Tests.Integration.Stress
{
    [TestFixture]
    public abstract class StressTests : IntegrationTests
    {
        [Inject]
        public Random Random { get; set; }
        [Inject]
        public Stopwatch Stopwatch { get; set; }
        [Inject]
        public ClientIDManager ClientIdManager { get; set; }
        [Inject]
        public GenEventQueue EventQueue { get; set; }

        private const int ConfidentIterations = 1000000;
        private const int TravisJobOutputTimeLimit = 60 * 10;
        private const int TravisJobBuildTimeLimit = 60 * 50;

        private readonly int timeLimitInSeconds;

        private int iterations;
        private Guid clientId;
        private DateTime eventCheckpoint;

        public StressTests()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var types = assembly.GetTypes();
            var methods = types.SelectMany(t => t.GetMethods());
            var stressTestsCount = methods.Sum(m => m.GetCustomAttributes<TestAttribute>(true).Count());
            var stressTestsCasesCount = methods.Sum(m => m.GetCustomAttributes<TestCaseAttribute>(true).Count());
            var stressTestsTotal = stressTestsCount + stressTestsCasesCount;

            var perTestTimeLimit = TravisJobBuildTimeLimit / stressTestsTotal;

            //INFO: This asserts that the stress tests should have enough time to generate even the rarest of occurrances
            Assert.That(perTestTimeLimit, Is.AtLeast(15));
#if STRESS
            timeLimitInSeconds = Math.Min(perTestTimeLimit, TravisJobOutputTimeLimit - 10);
#else
            timeLimitInSeconds = 1;
#endif
        }

        [SetUp]
        public void StressSetup()
        {
            clientId = Guid.NewGuid();
            ClientIdManager.SetClientID(clientId);

            iterations = 0;
            eventCheckpoint = new DateTime();

            Stopwatch.Start();
        }

        [TearDown]
        public void StressTearDown()
        {
            WriteStressSummary();
            WriteEventSummary();

            Stopwatch.Reset();
        }

        private void AssertEventSpacing()
        {
            var events = EventQueue.DequeueAll(clientId);

            //INFO: Have to put the events back in the queue for the summary at the end of the test
            foreach (var genEvent in events)
                EventQueue.Enqueue(genEvent);

            Assert.That(events, Is.Ordered.By("When"));

            var newEvents = events.Where(e => e.When > eventCheckpoint).ToArray();

            Assert.That(newEvents, Is.Ordered.By("When"));

            for (var i = 1; i < newEvents.Length; i++)
            {
                var failureMessage = $"{GetMessage(newEvents[i - 1])}\n{GetMessage(newEvents[i])}";
                Assert.That(newEvents[i].When, Is.EqualTo(newEvents[i - 1].When).Within(1).Seconds, failureMessage);
            }

            if (newEvents.Any())
                eventCheckpoint = newEvents.Last().When;
        }

        private void WriteStressSummary()
        {
            var iterationsPerSecond = Math.Round(iterations / Stopwatch.Elapsed.TotalSeconds, 2);
            Console.WriteLine($"Stress test complete after {Stopwatch.Elapsed} and {iterations} iterations, or {iterationsPerSecond} iterations per second");
        }

        private void WriteEventSummary()
        {
            var events = EventQueue.DequeueAll(clientId);

            //INFO: Get the 10 most recent events for TreasureGen.  We assume the events are ordered chronologically already
            events = events.Where(e => e.Source == "TreasureGen");
            events = events.Reverse();
            events = events.Take(10);
            events = events.Reverse();

            foreach (var genEvent in events)
                Console.WriteLine(GetMessage(genEvent));
        }

        private string GetMessage(GenEvent genEvent)
        {
            return $"[{genEvent.When.ToLongTimeString()}] {genEvent.Source}: {genEvent.Message}";
        }

        protected void Stress(Action generate)
        {
            do
            {
                generate();
                AssertEventSpacing();
            }
            while (TestShouldKeepRunning());
        }

        private bool TestShouldKeepRunning()
        {
            iterations++;
            return Stopwatch.Elapsed.TotalSeconds < timeLimitInSeconds && iterations < ConfidentIterations;
        }

        protected T GenerateOrFail<T>(Func<T> generate, Func<T, bool> isValid)
        {
            T generatedObject;

            do
            {
                generatedObject = generate();
                AssertEventSpacing();
            }
            while (TestShouldKeepRunning() && !isValid(generatedObject));

            if (!isValid(generatedObject))
                Assert.Fail($"Stress test timed out after {Stopwatch.Elapsed} and {iterations} iterations");

            return generatedObject;
        }

        protected T Generate<T>(Func<T> generate, Func<T, bool> isValid)
        {
            T generatedObject;

            do
            {
                generatedObject = generate();
                AssertEventSpacing();
            }
            while (!isValid(generatedObject));

            return generatedObject;
        }

        protected int GetNewLevel()
        {
            return Random.Next(1, 31);
        }

        protected string GetNewPower(bool allowMinor = true)
        {
            var limit = allowMinor ? 3 : 2;

            switch (Random.Next(limit))
            {
                case 0: return PowerConstants.Major;
                case 1: return PowerConstants.Medium;
                default: return PowerConstants.Minor;
            }
        }
    }
}