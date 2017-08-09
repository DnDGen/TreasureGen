using DnDGen.Stress;
using DnDGen.Stress.Events;
using EventGen;
using Ninject;
using NUnit.Framework;
using System;
using System.Reflection;
using TreasureGen.Items;

namespace TreasureGen.Tests.Integration.Stress
{
    [TestFixture]
    public abstract class StressTests : IntegrationTests
    {
        [Inject]
        public Random Random { get; set; }

        protected Stressor stressor;

        [OneTimeSetUp]
        public void StressSetup()
        {
            var options = new StressorWithEventsOptions();
            options.RunningAssembly = Assembly.GetExecutingAssembly();
            options.TimeLimitPercentage = .90;

#if STRESS
            options.IsFullStress = true;
#else
            options.IsFullStress = false;
#endif

            options.ClientIdManager = GetNewInstanceOf<ClientIDManager>();
            options.EventQueue = GetNewInstanceOf<GenEventQueue>();
            options.Source = "TreasureGen";

            stressor = new StressorWithEvents(options);
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